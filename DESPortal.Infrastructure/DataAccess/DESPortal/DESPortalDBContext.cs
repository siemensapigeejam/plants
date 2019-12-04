using DESPortal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DESPortal.Infrastructure.DataAccess.DESPortal
{
    public class DESPortalDBContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        
        public DESPortalDBContext(DbContextOptions<DESPortalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
