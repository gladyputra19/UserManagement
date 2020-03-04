using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementClient.ViewModels
{
    public class RoleVM : IdentityRole
    {
        public int Priority { get; set; }
    }
}
