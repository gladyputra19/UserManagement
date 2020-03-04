using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.ViewModels
{
    [Table("tb_m_major")]
    public class MajorVM : BaseModel
    {
        public string Name { get; set; }
    }
}
