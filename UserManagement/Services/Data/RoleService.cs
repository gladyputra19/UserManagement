using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repositories.Interfaces;
using UserManagement.Services.Interfaces;

namespace UserManagement.Services.Data
{
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public IEnumerable<Role> Get()
        {
            return _roleRepository.Get();
        }

        public Task<IEnumerable<Role>> Get(string Id)
        {
            return _roleRepository.Get(Id);
        }
    }
}
