using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper1.Comman
{
    public class Uitilty
    {
        private readonly IConfiguration _configuration;
        public Uitilty(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public SqlConnection GetConnectionString()
        {
            string connectionstring = _configuration.GetConnectionString("Win");
            return new SqlConnection(connectionstring);
        }
    }
}
