using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.ViewModels
{
    [Table("tb_m_department")]
    public class DepartmentVM : BaseModel
    {
        public string Name { get; set; }
        public int Division_Id { get; set; }
    }
}
