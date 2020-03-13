using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementClient.ViewModels
{
    public class UserRoleVM : IdentityUser
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string NIK { get; set; }
        public string Role { get; set; }
        public string Application { get; set; }
    }
}
