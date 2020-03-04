using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementClient.ViewModels
{
    public class UserRoleVM : IdentityUser
    {
        public string Employee_Id { get; set; }
        public string Role_Id { get; set; }
    }
}
