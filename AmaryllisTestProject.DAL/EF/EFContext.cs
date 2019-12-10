using AmaryllisTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

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
    }
}
