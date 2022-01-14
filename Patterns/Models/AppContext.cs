using Microsoft.EntityFrameworkCore;
using PatternsGoF.Facade;

namespace Patterns.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<PresidentNotes> Notes { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
