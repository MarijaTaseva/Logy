using LogyData.Models;
using Microsoft.EntityFrameworkCore;

namespace LogyData
{
    public class LogyContext : DbContext
    {
        public LogyContext(DbContextOptions options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
    }
}
