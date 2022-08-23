using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProcessPensionMicroservice.Data;
using System.IO;

namespace ProcessPensionModuleTest
{
    public static class ProcessPensionconfig
    {
        private static IConfiguration _configuration = null;
        private static string _connectionString = null;
        private static ApplicationDbContex _context;

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public static string GetConnectionString()
        {
            if (_configuration == null)
                _configuration = GetConfiguration();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return _connectionString;
        }

        public static ApplicationDbContex GetApplicationDbContext()
        {
            if (_configuration == null)
                _configuration = GetConfiguration();

            if (_connectionString == null)
                _connectionString = GetConnectionString();

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContex>()
                .UseSqlServer(_connectionString)
                .Options;

            _context = new ApplicationDbContex(dbContextOptions);
            return _context;
        }

    }
}
