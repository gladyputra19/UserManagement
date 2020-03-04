using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.ViewModels;

namespace UserManagement.Models
{
    [Table("tb_t_applicationusers")]
    public class ApplicationUser : BaseModel
    {
        public string Employee_Id { get; set; }
        public int Application_Id { get; set; }
        
        [ForeignKey("Employee_Id")]
        Employee Employees { get; set; }
        [ForeignKey("Application_Id")]
        Application Applications { get; set; }
    }
}
