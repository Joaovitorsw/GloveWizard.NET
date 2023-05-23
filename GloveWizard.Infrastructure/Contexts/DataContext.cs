using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

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
                .HasMany(Customers => Customers.contacts)
                .WithOne(Contacts => Contacts.customers)
                .HasForeignKey(Contacts => Contacts.customer_id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
