using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserManagement.Auths;
using UserManagement.Models;
using UserManagement.Services.Interfaces;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        IConfiguration _configuration;
        IRoleService _roleService;
        UserManager<Employee> _userManager;
        public RolesController(
            IRoleService roleService,
            RoleManager<Role> roleManager,
            IConfiguration configuration

            )
        {
            _roleService = roleService;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _roleService.Get();
        }
        [HttpGet("{Id}")]
        public Role Get(string Id)
        {

            return _roleService.Get(Id);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var check = await _roleManager.FindByIdAsync(Id);
            var result = await _roleManager.DeleteAsync(check);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Role model)
        {
            if (ModelState.IsValid)
            {
                var role = new Role();
                role.Id = model.Id;
                role.Name = model.Name;
                role.Priority = model.Priority;
                role.CreateDate = DateTime.Now.ToLocalTime();
                var check = await _roleManager.RoleExistsAsync(model.Name);
                if(check == true)
                {
                    return BadRequest();
                }
                else { 
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(string Id,RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {

                var role = await _roleManager.FindByIdAsync(Id);
                role.Id = roleVM.Id;
                role.Name = roleVM.Name;
                role.Priority = roleVM.Priority;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}