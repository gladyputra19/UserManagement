using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_region")]
    public class Region:IEntity,IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Regency_Id { get; set; }

        [ForeignKey("Regency_Id")]
        public Regency Regencies { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        public Region()
        {

        }
        public Region(RegionVM regionVM)
        {
            Id = regionVM.Id;
            Name = regionVM.Name;
            Regency_Id = regionVM.Regency_Id;
            CreateDate = DateTime.Now.ToLocalTime();
        }
        public void Update (int Id, RegionVM regionVM)
        {
            Id = regionVM.Id;
            Name = regionVM.Name;
            Regency_Id = regionVM.Regency_Id;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
