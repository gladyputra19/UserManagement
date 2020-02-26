using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_division")]
    public class Division : IEntity,IStatus
    {
        public int Id { get ; set ; }
        public string Name { get; set; }

        public DateTime CreateDate { get ; set ; }
        public DateTime UpdateDate { get ; set; }
        public DateTime DeleteDate { get; set ; }
        public bool isDelete { get; set; }

        public Division()
        {

        }
        public Division(DivisionVM divisionVM)
        {
            Id = divisionVM.Id;
            Name = divisionVM.Name;
            CreateDate = DateTime.Now.ToLocalTime();
        }
        public void Update(int Id, DivisionVM divisionVM)
        {
            Id = divisionVM.Id;
            Name = divisionVM.Name;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
