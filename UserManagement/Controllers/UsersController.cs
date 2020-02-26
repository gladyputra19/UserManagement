using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Models;
using UserManagement.Services.Interfaces;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        //role manager
        IConfiguration _configuration;
        IUserService _userService;
        public UsersController(IUserService userService,
            IConfiguration configuration,
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager
            )
        {
            _configuration = configuration;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _userService.Get();
        }
        [HttpGet("{Id}")]
        public Task<IEnumerable<Employee>> Get(string Id)
        {
            return _userService.Get(Id);
        }
        [HttpPost]
        public IActionResult Post(UserVM userVM)
        {
            var result = _userService.Post(userVM);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest("Failed to Add User");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id) {
            var result = _userService.Delete(Id);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public IActionResult Put(string Id, UserVM userVM)
        {
            var result = _userService.Put(Id, userVM);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new Employee { };
                    user.Id = Guid.NewGuid().ToString();
                    user.Email = model.Email;
                    user.UserName = user.Email;
                    user.PasswordHash = model.PasswordHash;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var a = await _userManager.GetSecurityStampAsync(user);
                    user.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    user.TokenStatus = true;

                    var result = await _userManager.CreateAsync(user, model.PasswordHash);
                    if (result.Succeeded)
                    {
                        return Ok("Register Success");
                    }
                }
                catch
                {
                    throw;
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserVM userVM)
        {
            var result = await _signInManager.PasswordSignInAsync(userVM.UserName, userVM.PasswordHash, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userVM.UserName);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddHours(12),
                        signingCredentials: signIn
                );
                    var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                    claims.Add(new Claim("TokenSecurity", idtoken));
                    return Ok(idtoken + "..." + user.UserName);
                }

            }
            return BadRequest(new { message = "Username or Password is Invalid" });
        }
        //[HttpPut("ForgotPassword")]
        //public async Task<ActionResult> ForgotPassword(string Id, UserVM userVM)
        //{
        //    var result =   _userService.ResetPassword(Id, userVM);
        //    if (result > 0)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
        [HttpPut("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string token, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(userVM.UserName);
                    user.PasswordHash = userVM.PasswordHash;
                    user.Token = token;
                    var result = await _userManager.ResetPasswordAsync(user, user.Token, userVM.PasswordHash);
                    if (result.Succeeded)
                    {
                        user.TokenStatus = false;
                        return Ok("Reset Succeed");
                    }
                }
                catch
                {
                    throw;
                }

            }
            return BadRequest(ModelState);
        }
    }
}