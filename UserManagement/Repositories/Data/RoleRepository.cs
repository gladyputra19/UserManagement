using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using UserManagement.ConnectionStrings;
using UserManagement.Models;
using UserManagement.Repositories.Interfaces;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Data
{
    public class RoleRepository : IRoleRepository
    {
        public IConfiguration _configuration;
        public readonly ConnectionString _connectionString;

        public RoleRepository(
            ConnectionString connectionString,
            IConfiguration configuration

            )
        {
            _configuration = configuration;
            _connectionString = connectionString;
            // dependency injection
        }
        DynamicParameters param = new DynamicParameters();
        
        public IEnumerable<Role> Get()
        {
            var procName = "SP_GetAllRole";

            var roles = _connectionString.Connections.Query<Role>(procName, param, commandType: CommandType.StoredProcedure);
            return roles;
        }

        public Role Get(string Id)
        {
            var procName = "SP_GetRoleById";
            param.Add("@p_Id", Id);

            var roles = _connectionString.Connections.QueryAsync<Role>(procName, param, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return roles;
        }
    }
}
