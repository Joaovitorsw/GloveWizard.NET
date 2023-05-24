using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GloveWizard.Data.Contexts
{
    public class DataContext : DbContext, IDisposable
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customers>()
                .HasMany(Customers => Customers.Contacts)
                .WithOne(Contacts => Contacts.Customers)
                .HasForeignKey(Contacts => Contacts.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<Users>()
                .Property(user => user.Roles)
                .HasConversion(
                    from => string.Join(";", from),

                    to =>
                        string.IsNullOrEmpty(to)
                            ? new List<string>()
                            : to.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList(),

                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()
                    )
                );
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
