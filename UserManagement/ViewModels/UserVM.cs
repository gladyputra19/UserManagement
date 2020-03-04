using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagement.ViewModels
{
    public class UserVM : IdentityUser
    {
        public string Token { get; set; }
        public bool TokenStatus { get; set; }
        public bool LockedStatus { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string NIK { get; set; }
        public string Role_Name { get; set; }
        public int Department_Id { get; set; }
        public int Major_Id { get; set; }
        public int Religion_Id { get; set; }
        public int Degree_Id { get; set; }
        public int Regency_Id { get; set; }
        public int JobTitle_Id { get; set; }
        public int Bootcamp_Id { get; set; }
        public string University { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }
    }
}
