using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Bases
{
    interface IEntity
    {
        [Key]
        int Id { get; set; }
        
    }
}
