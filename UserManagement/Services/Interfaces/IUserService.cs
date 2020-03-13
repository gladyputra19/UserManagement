using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Employee> Get();
        Employee Get(string Id);
        Employee GetToken(string Token);
        IEnumerable<UserVM> GetUserManager();
        Task<int> AddApplication(string UserId, ApplicationUser applicationUser);
        Application GetApplication(int Id);
        ApplicationUser GetApplicationUser(int Id);

    }
}
