using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repositories.Interfaces;
using UserManagement.Services.Interfaces;
using UserManagement.ViewModels;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Delete(string Id)
        {
            return _userRepository.Delete(Id);
        }

        public IEnumerable<Employee> Get()
        {
            return _userRepository.Get();
        }

        public Task<IEnumerable<Employee>> Get(string Id)
        {
            return _userRepository.Get(Id);
        }

        public int Post(UserVM userVM)
        {
            return _userRepository.Post(userVM);
        }

        public int Put(string Id, UserVM userVM)
        {
            return _userRepository.Put(Id, userVM);
        }

        public int ResetPassword(string Id, UserVM userVM)
        {
            return _userRepository.ResetPassword(Id, userVM);
        }
    }
}
