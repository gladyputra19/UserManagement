using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_religion")]
    public class Religion : IEntity, IStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool isDelete { get; set; }

        public Religion()
        {

        }
        public Religion(ReligionVM religionVM)
        {
            Id = religionVM.Id;
            Name = religionVM.Name;
            CreateDate = DateTime.Now.ToLocalTime();
        }
        public void Update(int Id, ReligionVM religionVM)
        {
            Id = religionVM.Id;
            Name = religionVM.Name;
            UpdateDate = DateTime.Now.ToLocalTime();
        }
        public void Delete()
        {
            DeleteDate = DateTime.Now.ToLocalTime();
            isDelete = true;
        }
    }
}
