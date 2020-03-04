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
    public class Regency : BaseModel
    {
        public string Name { get; set; }
        public int Province_Id { get; set; }

        [ForeignKey("ProvinceId")]
        public Province Provinces { get; set; }
    }
}
