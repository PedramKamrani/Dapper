using Dapper1.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Dapper1.Services
{
    public class Win : Iwin
    {
        private IConfiguration _configuration;

        public Win(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<WinViewModel>> GetAll()
        {
            string connectionstrings = _configuration.GetConnectionString("Win");
            //var connection = _configuration["ConnectionStrings:win"];

            var query = "select id, one,two from win2";
            using (IDbConnection connection =new SqlConnection(connectionstrings))
            {
                var result = await connection.QueryAsync<WinViewModel>(query);
                return result.ToList();
            }
        }
    }
}
