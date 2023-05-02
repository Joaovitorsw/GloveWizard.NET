using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace GloveWizard.Data.Contexts
{
    public class DataContext : DbContext, IDisposable
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public virtual DbSet<Customers> Customers { get; set; }

    
    }

}


