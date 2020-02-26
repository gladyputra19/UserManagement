using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_regency")]
    public class Regency : IEntity, IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Province_Id { get; set; }

        [ForeignKey("Province_Id")]
        public Province Provinces { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        public Regency()
        {

        }
        public Regency(RegencyVM regencyVM)
        {
            Id = regencyVM.Id;
            Name = regencyVM.Name;
            Province_Id = regencyVM.Province_Id;
            CreateDate = DateTime.Now.ToLocalTime();
        }
        public void Update(int Id, RegencyVM regencyVM)
        {
            Id = regencyVM.Id;
            Name = regencyVM.Name;
            Province_Id = regencyVM.Province_Id;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
