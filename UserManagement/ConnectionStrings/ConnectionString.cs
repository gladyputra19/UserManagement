using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.ConnectionStrings
{
    public class ConnectionString
    {
        public ConnectionString(string value) => Value = value; //Untuk mendapatkan nilai dari connectionStrings
        
        public string Value { get; }
    }
}
