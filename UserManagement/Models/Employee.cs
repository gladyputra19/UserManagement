using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagement.Models
{
    public class Employee : IdentityUser
    {
        public string Token { get; set; }
        public bool TokenStatus { get; set; }
    }
}
