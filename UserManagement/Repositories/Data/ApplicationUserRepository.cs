using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using UserManagement.ConnectionStrings;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Data
{
    public class ApplicationUserRepository : GeneralRepository<ApplicationUserVM>
    {
        private readonly ConnectionString _connectionString;
        DynamicParameters param = new DynamicParameters();
        public ApplicationUserRepository(ConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }
        
        [HttpGet]
        public IEnumerable<ApplicationUserVM> Get()
        {
            var query = "SP_GetApplicationUser";
            var result = _connectionString.Connections.Query<ApplicationUserVM>(query, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
        [HttpPost]
        public  int Create(ApplicationUser applicationUser)
        {
            var query = "SP_CreateApplicationUser";
            var result = _connectionString.Connections.Execute(query, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        [HttpGet]
        public ApplicationUser Get(string Id)
        {
            var query = "SP_GetByEmployeeId";
            var result = _connectionString.Connections.QueryAsync<ApplicationUser>(query, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return result;
        }
    }
}
