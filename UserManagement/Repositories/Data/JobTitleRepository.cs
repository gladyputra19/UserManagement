using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.ConnectionStrings;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Data
{
    public class JobTitleRepository : GeneralRepository<JobTitleVM>
    {
        public JobTitleRepository(ConnectionString connectionString) : base(connectionString)
        {
        }
    }
}
