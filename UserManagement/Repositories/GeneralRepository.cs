using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using UserManagement.Bases;
using UserManagement.ConnectionStrings;
using UserManagement.Repositories.Interfaces;

namespace UserManagement.Repositories
{
    public class GeneralRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        readonly ConnectionString _connectionString;

        public GeneralRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> Delete(int Id)
        {
            var entity = await _connectionString.Connections.GetAsync<TEntity>(Id);
            var delete = await _connectionString.Connections.DeleteAsync(entity);
            return delete;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var getAll = await _connectionString.Connections.GetAllAsync<TEntity>();
            return getAll;
        }

        public async Task<TEntity> Get(int Id)
        {
            var getByID = await _connectionString.Connections.GetAsync<TEntity>(Id);
            return getByID;
        }

        public async Task<int> Post(TEntity entity)
        {
            var post = await _connectionString.Connections.InsertAsync(entity);
            return post;
        }

        public async Task<bool> Put(TEntity entity)
        {
            var put = await _connectionString.Connections.UpdateAsync(entity);
            return put;
        }
    }
}
