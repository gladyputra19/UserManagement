using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_m_bootcamp")]
    public class Bootcamp : BaseModel
    {
        public string Name { get; set; }
        public int Batch_Id { get; set; }
        public int Major_Id { get; set; }
        public string Employee_Id { get; set; }

        [ForeignKey("Major_Id")]
        public Major Majors { get; set; }

        [ForeignKey("Batch_Id")]
        public Batch Batches { get; set; }

        [ForeignKey("Employee_Id")]
        public Employee Employees { get; set; }
    }
}
