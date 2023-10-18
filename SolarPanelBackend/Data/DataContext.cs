using Microsoft.EntityFrameworkCore;

namespace SolarPanelBackend.Data
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
