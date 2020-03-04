using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    public class Role : IdentityRole, IStatus
    {
        public int Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        public Role(){}

        public Role(RoleVM roleVM)
        {
            Id = roleVM.Id;
            Name = roleVM.Name;
            Priority = roleVM.Priority;
            CreateDate = DateTime.Now.ToLocalTime();
        }
        public void Update(string Id, RoleVM roleVM)
        {
            Id = roleVM.Id;
            Name = roleVM.Name;
            Priority = roleVM.Priority;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
