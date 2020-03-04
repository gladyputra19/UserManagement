using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserManagement.ConnectionStrings
{
    public class ConnectionString
    {
        public MySqlConnection Connections { get; }

        public ConnectionString(string connectionString)
        {
            Connections = new MySqlConnection(connectionString);
            this.Connections.Open();
        }

        public void Dispose()
        {
            Connections.Close();
        }
    }
}
