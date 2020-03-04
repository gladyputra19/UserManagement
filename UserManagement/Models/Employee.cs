using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    public class Employee : IdentityUser, IStatus
    {
        public string Token { get; set; }
        public bool TokenStatus { get; set; }
        public bool LockedStatus { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string NIK { get; set; }
        public int Department_Id { get; set; }
        public int Major_Id { get; set; }
        public int Religion_Id { get; set; }
        public int Degree_Id { get; set; }
        public int Regency_Id { get; set; }
        public int JobTitle_Id { get; set; }
        public string University { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        [ForeignKey("Department_Id")]
        public Department Departments { get; set; }
        [ForeignKey("Major_Id")]
        public Major Majors { get; set; }
        [ForeignKey("Religion_Id")]
        public Religion Religions { get; set; }
        [ForeignKey("Degree_Id")]
        public Degree Degrees { get; set; }
        [ForeignKey("Regency_Id")]
        public Regency Regencies { get; set; }
        [ForeignKey("JobTitle_Id")]
        public JobTitle JobTitles { get; set; }

        public Employee(){}

        public Employee(UserVM userVM)
        {
            Id = userVM.Id;
            Name = userVM.Name;
            Email = userVM.Email;
            UserName = userVM.UserName;
            PasswordHash = userVM.PasswordHash;
            PhoneNumber = userVM.PhoneNumber;
            Address = userVM.Address;
            BirthDate = userVM.BirthDate;
            NIK = userVM.NIK;
            Department_Id = userVM.Department_Id;
            Major_Id = userVM.Major_Id;
            Religion_Id = userVM.Religion_Id;
            Regency_Id = userVM.Regency_Id;
            Degree_Id = userVM.Degree_Id;
            JobTitle_Id = userVM.JobTitle_Id;
            University = userVM.University;
            JoinDate = DateTime.Now.ToLocalTime();
            CreateDate = JoinDate;
        }
        public void Update(string Id, UserVM userVM)
        {
            Id = userVM.Id;
            Name = userVM.Name;
            Email = userVM.Email;
            UserName = userVM.UserName;
            PasswordHash = userVM.PasswordHash;
            PhoneNumber = userVM.PhoneNumber;
            Address = userVM.Address;
            BirthDate = userVM.BirthDate;
            NIK = userVM.NIK;
            Department_Id = userVM.Department_Id;
            Major_Id = userVM.Major_Id;
            Religion_Id = userVM.Religion_Id;
            Regency_Id = userVM.Regency_Id;
            Degree_Id = userVM.Degree_Id;
            JobTitle_Id = userVM.JobTitle_Id;
            University = userVM.University;
            JoinDate = userVM.JoinDate;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
