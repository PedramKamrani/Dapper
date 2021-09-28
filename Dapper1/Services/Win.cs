using Dapper1.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Dapper1.Comman;

namespace Dapper1.Services
{
    public class Win : Iwin
    {
        private IConfiguration _configuration;
        private readonly Uitilty _uitilty;

        public Win(IConfiguration configuration,Uitilty uitilty)
        {
            _configuration = configuration;
            _uitilty = uitilty;
        }
        public async Task<List<WinViewModel>> GetAll()
        {
            //string connectionstrings = _configuration.GetConnectionString("Win");
            //var connection = _configuration["ConnectionStrings:win"];

            var query = "select id, one,two from win2";
            using (IDbConnection connection =_uitilty.GetConnectionString())
            {
                var result = await connection.QueryAsync<WinViewModel>(query);
                return result.ToList();
            }
        }

        public async Task Add(CreateViewModel model)
        {
          //  var query = "@insert(one,two) values(@One,@Two)";
            var query = "SP_Win_Insert";
            using (IDbConnection connection = _uitilty.GetConnectionString())
            {
                 //await connection.ExecuteAsync(query,model);
                 await connection.ExecuteAsync(query,model,commandType:CommandType.StoredProcedure);
            }
        }
    }
}
