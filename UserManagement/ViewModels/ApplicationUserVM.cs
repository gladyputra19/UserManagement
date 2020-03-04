using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.ViewModels
{
    [Table("tb_t_applicationusers")]
    public class ApplicationUserVM : BaseModel
    {
        public string Employee_Id { get; set; }
        public int Application_Id { get; set; }
        
    }
}
