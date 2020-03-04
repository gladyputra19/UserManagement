using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_major")]
    public class Major : BaseModel
    {
        public string Name { get; set; }
    }
}
