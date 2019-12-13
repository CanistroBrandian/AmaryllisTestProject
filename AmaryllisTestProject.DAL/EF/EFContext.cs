using AmaryllisTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AmaryllisTestProject.DAL.EF
{
    public class EFContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
             : base(options)
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
    }
}
