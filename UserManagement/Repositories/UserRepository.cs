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

        public bool Delete(string Id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value))
            {
                var procName = "SP_DeleteUser";
                param.Add("@p_Id", Id);

                var users = connection.Execute(procName, param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public IEnumerable<Employee> Get()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value))
            {
                var procName = "SP_GetAllUser";
                
                var users = connection.Query<Employee>(procName, param, commandType: CommandType.StoredProcedure);
                return users;
            }
        }

        public async Task<IEnumerable<Employee>> Get(string Id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value)) {

            var procName = "SP_GetById";
            param.Add("@p_Id", Id);

            var users = await connection.QueryAsync<Employee>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
            return users;
            }
        }

        public int Post(UserVM userVM)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value))
            {
                
                var procName = "SP_CreateUser";
                param.Add("@p_Email", userVM.UserName);
                param.Add("@p_UserName", userVM.UserName);
                param.Add("@p_PasswordHash", userVM.UserName);

                var users = connection.Execute(procName, param, commandType: System.Data.CommandType.StoredProcedure);
                return users;
                
            }
        }

        public int Put(string Id, UserVM userVM)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value))
            {
                var procName = "SP_EditUser";
                param.Add("@p_Id", Id);
                param.Add("@p_Email", userVM.UserName);
                param.Add("@p_UserName", userVM.UserName);
                param.Add("@p_PasswordHash", userVM.UserName);

                var users = connection.Execute(procName, param, commandType: System.Data.CommandType.StoredProcedure);
                return users;
            }
        }

        public int ResetPassword (string Id, UserVM userVM)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString.Value))
            {
                var procName = "SP_Select_By_UserName";
                param.Add("@p_UserName", userVM.UserName);

                var slog = connection.QueryAsync<UserVM>(procName, param, commandType: CommandType.StoredProcedure).Result.SingleOrDefault();
                if(slog.UserName == userVM.UserName)
                {
                    var procName1 = "SP_Select_Token_By_UserName";
                    param.Add("@p_Username", userVM.UserName);

                    var check = connection.QueryAsync<UserVM>(procName1, param, commandType: CommandType.StoredProcedure).Result.SingleOrDefault();
                    if(check.Token == slog.Token)
                    {
                        var procName2 = "SP_Reset_Password";
                        param.Add("@p_Id", check.Id);
                        param.Add("@p_PasswordHash", userVM.PasswordHash);

                        var users = connection.Execute(procName2, param, commandType: CommandType.StoredProcedure);
                        return users;
                    }
                }
                return 0;
            }
        }
    }
}
