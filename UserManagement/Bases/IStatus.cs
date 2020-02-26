using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Bases
{
    interface IStatus
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime DeleteDate { get; set; }

        bool isDelete { get; set; }
    }
}
