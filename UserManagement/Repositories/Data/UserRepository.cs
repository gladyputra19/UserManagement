using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repositories.Interfaces;
using UserManagement.ViewModels;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using UserManagement.ConnectionStrings;
using Microsoft.AspNetCore.Identity;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {

        public IConfiguration _configuration;
        public readonly ConnectionString _connectionString;

        public UserRepository(
            ConnectionString connectionString,
            IConfiguration configuration

            )
        {
            _configuration = configuration;
            _connectionString = connectionString;
            // dependency injection
        }
        DynamicParameters param = new DynamicParameters();
        
        public IEnumerable<Employee> Get()
        {
            var procName = "SP_GetAllUser";

            var users = _connectionString.Connections.Query<Employee>(procName, param, commandType: CommandType.StoredProcedure);
            return users;
        }

        public Employee Get(string Id)
        {
            var procName = "SP_GetById";
            param.Add("@p_Id", Id);

            var users =  _connectionString.Connections.QueryAsync<Employee>(procName, param, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return users;
        }
        public Employee GetToken(string Token)
        {
            var procName1 = "SP_GetByToken";
            param.Add("@p_Token", Token);

            var check = _connectionString.Connections.QueryAsync<Employee>(procName1, param, commandType: CommandType.StoredProcedure).Result.SingleOrDefault();
            return check;
        }
    }
}
