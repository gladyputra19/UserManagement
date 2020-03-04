using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> Get();
        Task<IEnumerable<Role>> Get(string Id);
    }
}
