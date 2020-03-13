using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Models;
using UserManagement.Services.Interfaces;
using UserManagement.ViewModels;
using System.Net.Mail;
using System.Net;

namespace UserManagement.Controllers
{
    [Route("[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        IConfiguration _configuration;
        IUserService _userService;
        IRoleService _roleService;
        public UsersController(IUserService userService,
            IConfiguration configuration,
            UserManager<Employee> userManager,
            RoleManager<Role> roleManager,
            SignInManager<Employee> signInManager,
            IRoleService roleService
            )
        {
            _configuration = configuration;
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _roleService = roleService;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _userService.Get();
        }
        [HttpGet("{Id}")]
        public Employee Get(string Id)
        {
            return _userService.Get(Id);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id)
        {
            var check = _userManager.FindByIdAsync(Id).Result;
            var result = _userManager.DeleteAsync(check).Result;
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public IActionResult Put(string Id)
        {
            var check = _userManager.FindByIdAsync(Id).Result;
            var result = _userManager.UpdateAsync(check).Result;
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("{Token}")]
        public Employee GetToken(string Token)
        {
            var result = _userService.GetToken(Token);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        [HttpPost]
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
                    user.PhoneNumber = model.PhoneNumber;
                    user.Address = model.Address;
                    user.BirthDate = model.BirthDate;
                    user.Name = model.Name;
                    user.NIK = model.NIK;
                    user.JoinDate = DateTime.Now.ToLocalTime();
                    user.CreateDate = user.JoinDate;
                    user.Department_Id = model.Department_Id;
                    user.Religion_Id = model.Religion_Id;
                    user.Regency_Id = model.Regency_Id;
                    user.Degree_Id = model.Degree_Id;
                    user.JobTitle_Id = model.JobTitle_Id;
                    user.University = model.University;
                    user.SecurityStamp = _userManager.GetSecurityStampAsync(user).ToString();
                    user.LockoutEnd = DateTime.Now.AddYears(100);
                    user.LockedStatus = true;
                    var result = await _userManager.CreateAsync(user, model.PasswordHash);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Staff");
                        string code = Guid.NewGuid().ToString();
                        var callbackUrl = "http://192.168.128.119:1708/ConfirmEmail/" + code + "/" + user.Id;
                        string message = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">this link</a>";

                        MailMessage sMail = new MailMessage();
                        sMail.To.Add(new MailAddress(model.Email));
                        sMail.From = new MailAddress("cobamvc@gmail.com");
                        sMail.Subject = "[Account Confirmation] " + DateTime.Now.ToString("dd/mm/yyyy/hh:mm:ss");
                        sMail.Body = message;
                        sMail.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("cobamvc@gmail.com", "@Bootcamp33");
                        smtp.Send(sMail);
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
        [HttpGet("{code}/{Id}")]
        [Route("{code}/{Id}")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string code, string Id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var result = await _userManager.ConfirmEmailAsync(user, token);
                    if (result.Succeeded)
                    {
                        user.LockedStatus = false;
                        user.LockoutEnd = DateTime.Now.ToLocalTime();
                        await _userManager.UpdateAsync(user);
                        return Ok();
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserVM userVM)
        {
            var result = await _signInManager.PasswordSignInAsync(userVM.UserName, userVM.PasswordHash, false, true);
            var user = await _userManager.FindByNameAsync(userVM.UserName);

            if (result.IsLockedOut)
            {
                if (user != null)
                {
                    user.LockedStatus = true;
                    await _userManager.UpdateAsync(user);
                    var statusCode = 300;
                    var token = user.Token;
                    return BadRequest(statusCode + "..." + token);
                }
            }
            else if (result.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                List<int> temp = new List<int>();

                foreach (var i in role)
                {
                    var priority = await _roleManager.FindByNameAsync(i);
                    temp.Add(priority.Priority);
                }

                int change = 0;

                if (role.Count > 0)
                {
                    for (int i = 0; i < role.Count() - 1; i++)
                    {
                        for (int j = 0; j < role.Count() - 1; j++)
                        {
                            if (temp[j] > temp[j + 1])
                            {
                                change = temp[j + 1];
                                temp[j + 1] = temp[j];
                                temp[j] = change;
                                var priority = await _roleManager.FindByNameAsync(role[change]);
                                userVM.Role_Name = priority.Name;
                            }
                        }
                    }
                }
                var check = await _roleManager.FindByNameAsync(role[change]);
                userVM.Role_Name = check.Name;
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
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                return Ok(idtoken + "..." + user.UserName + "..." + user.Id + "..." + userVM.Role_Name);
            }
            else
            {
                var message = "Username or Password is Invalid";
                return BadRequest(user.AccessFailedCount + "..." + message);
            }
            return NotFound();
        }
        [HttpPut("{Token}")]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(string Token, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(userVM.Email);
                    if (user.Token == Token)
                    {
                        user.PasswordHash = userVM.PasswordHash;
                        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var result = await _userManager.ResetPasswordAsync(user, code, userVM.PasswordHash);
                        user.TokenStatus = false;
                        var status = await _userManager.UpdateAsync(user);
                        if (status.Succeeded)
                        {
                            return Ok(user);
                        }
                    }
                }
                catch
                {
                    throw;
                }

            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> GenerateResetPasswordToken(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(userVM.Email);
                    user.Token = Guid.NewGuid().ToString();
                    user.TokenStatus = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Ok(user);
                    }
                    return Ok(user);
                }
                catch
                {
                    throw;
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new Employee { };
                user.Email = userVM.Email;
                user.UserName = userVM.Email;
                user.PhoneNumber = userVM.PhoneNumber;
                user.Address = userVM.Address;
                user.BirthDate = userVM.BirthDate;
                user.NIK = userVM.NIK;
                user.Name = userVM.Name;
                user.UpdateDate = DateTime.Now.ToLocalTime();
                user.Department_Id = userVM.Department_Id;
                user.Religion_Id = userVM.Religion_Id;
                user.Regency_Id = userVM.Regency_Id;
                user.Degree_Id = userVM.Degree_Id;
                user.JobTitle_Id = userVM.JobTitle_Id;
                user.University = userVM.University;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost("{IdUser}")]
        public async Task<ActionResult> AddToRole(string IdUser, RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(IdUser);
                if (user != null)
                {
                    var role = await _roleManager.FindByIdAsync(roleVM.Id);
                    var check = await _userManager.IsInRoleAsync(user, role.Name);
                    if (check == true)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var add = await _userManager.AddToRoleAsync(user, role.Name);
                        if (add.Succeeded)
                        {
                            return Ok(add);
                        }
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            return BadRequest();
        }
        //[HttpPost("{Token}")]
        //public async Task<ActionResult> LockedAccount(string Token)
        //{
        //    var token = GetToken(Token);
        //    if(token != null)
        //    {
        //        return token;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            return _roleService.Get();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            var logout = _signInManager.SignOutAsync();
            if (logout.IsCompletedSuccessfully)
            {
                return Ok();
            }
            return BadRequest();
        }
        public IEnumerable<UserVM> GetUserManager()
        {
            return _userService.GetUserManager();
        }
        [HttpPost("{UserId}")]
        public async Task<IActionResult> AddToApplication(string UserId, ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                    var user = await _userManager.FindByIdAsync(UserId);
                    if (user != null)
                    {
                        applicationUser.Create();
                        applicationUser.Employee_Id = user.Id;
                        var add = await _userService.AddApplication(user.Id, applicationUser);
                        if (add > 0)
                        {
                            return Ok(add);
                        }
                        return BadRequest();
                    }
                }
            return NotFound();

                }
    }
}