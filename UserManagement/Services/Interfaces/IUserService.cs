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
        Task<IEnumerable<Employee>> Get(string Id);
        int Post(UserVM userVM);
        int Put(string Id, UserVM userVM);
        int ResetPassword(string Id, UserVM userVM);
        bool Delete(string Id);
    }
}
