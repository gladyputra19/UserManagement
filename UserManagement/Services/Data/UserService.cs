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

        public Task<int> AddApplication(string UserId, ApplicationUser applicationUser)
        {
            return _userRepository.AddApplication(UserId, applicationUser);
        }

        public IEnumerable<Employee> Get()
        {
            return _userRepository.Get();
        }
        public Employee Get(string Id)
        {
            return _userRepository.Get(Id);
        }

        public Application GetApplication(int Id)
        {
            return _userRepository.GetApplication(Id);
        }

        public ApplicationUser GetApplicationUser(int Id)
        {
            return _userRepository.GetApplicationUser(Id);
        }

        public Employee GetToken(string Token)
        {
            return _userRepository.GetToken(Token);
        }
        public IEnumerable<UserVM> GetUserManager()
        {
            return _userRepository.GetUserManager();
        }
    }
}
