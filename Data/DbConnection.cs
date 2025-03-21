using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Npgsql;

namespace DbAdo.data
{
    public class DbConnection
    {
        // Private property connection string
        private string _connectionString;

        // constructor
        public DbConnection()
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true).Build();
            
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        
        public NpgsqlConnection GetConnection()
        {
            // Returns a connection to the database. parameter is the connection string
            return new NpgsqlConnection(_connectionString);
        }
    }
}
