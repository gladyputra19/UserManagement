using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Bases;
using UserManagement.Models;
using UserManagement.Repositories.Data;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : BasesController<ApplicationVM,ApplicationRepository>
    {
        public ApplicationsController(ApplicationRepository applicationRepository):base(applicationRepository)
        {

        }
    }
}