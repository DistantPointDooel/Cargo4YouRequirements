using Cargo4You.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cargo4You.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ParcelChecks> ParcelChecks { get; set; }
        public DbSet<Validations> Validations { get; set; }
        public DbSet<Couriers> Couriers { get; set; }
    }
}
