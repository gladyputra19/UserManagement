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
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public int Division_Id { get; set; }

        [ForeignKey("Division_Id")]
        public Division Divisions { get; set; }
    }
}
