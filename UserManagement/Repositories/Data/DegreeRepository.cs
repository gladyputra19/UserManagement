using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.ConnectionStrings;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Data
{
    public class DegreeRepository : GeneralRepository<DegreeVM>
    {
        public DegreeRepository(ConnectionString connectionString) : base(connectionString)
        {
        }
    }
}
