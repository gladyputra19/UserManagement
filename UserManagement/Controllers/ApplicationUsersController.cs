using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Bases;
using UserManagement.Models;
using UserManagement.Repositories.Data;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationUsersController : BasesController<ApplicationUserVM,ApplicationUserRepository>
    {
        ApplicationUserRepository _applicationUserRepository;
        private readonly UserManager<Employee> _userManager;
        public ApplicationUsersController(ApplicationUserRepository applicationUserRepository, UserManager<Employee> userManager):base(applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string Id, ApplicationUserVM applicationUserVM)
        {
            var check = _userManager.FindByIdAsync(Id);
            if (check != null)
            {
                var log = _applicationUserRepository.Get(Id);
                if(log.Application_Id != applicationUserVM.Application_Id)
                {
                    applicationUserVM.Create();
                    var create = await _applicationUserRepository.Post(applicationUserVM);
                    if (create > 0)
                    {
                        return Ok(create + " data has been created");
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}