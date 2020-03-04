using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.ViewModels
{
    [Table("tb_m_regency")]
    public class RegencyVM :BaseModel
    {
        public string Name { get; set; }
        public int Province_Id { get; set; }
    }
}
