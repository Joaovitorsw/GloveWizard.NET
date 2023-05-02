using GloveWizard.Data.Contexts;
using GloveWizard.Data.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GloveWizard.Infrastructure.Entities
{
    public partial class CustomersContext : DbContext, IDisposable
    {
    

        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }

        public void Save()
        {
            base.SaveChanges();
        }
    }

}




