using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_department")]
    public class Department : IEntity,IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Division_Id { get; set; }

        [ForeignKey("Division_Id")]
        public Division Divisions { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        public Department()
        {

        }
        public Department(DepartmentVM departmentVM)
        {
            Id = departmentVM.Id;
            Name = departmentVM.Name;
            Division_Id = departmentVM.Division_Id;
            CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(int Id, DepartmentVM departmentVM)
        {
            Id = departmentVM.Id;
            Name = departmentVM.Name;
            Division_Id = departmentVM.Division_Id;
            UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
