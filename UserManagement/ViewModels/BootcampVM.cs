using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.ViewModels
{
    [Table("tb_m_bootcamp")]
    public class BootcampVM : BaseModel
    {
        public string Name { get; set; }
        public int Batch_Id { get; set; }
        public int Major_Id { get; set; }
    }
}
