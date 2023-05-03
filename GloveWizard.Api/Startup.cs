using GloveWizard.Configurations;

namespace GloveWizard
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.CreateMapper();
            services.ResolveDependencies();
            services.AddDatabaseContext(Configuration);
            services.AddSwaggerConfig();
            services.AddWebApiConfiguration(MyAllowSpecificOrigins);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiMiddleware(MyAllowSpecificOrigins);
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseHsts();
            app.UseSwaggerConfig();
        }
    }
}






