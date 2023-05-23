using GloveWizard.Data.Contexts;
using GloveWizard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloveWizard
{
    public static class ContextConfig
    {
        public static void AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(
                (options) =>
                {
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.UseSqlServer(connectionString);
                }
            );
        }
    }
}
