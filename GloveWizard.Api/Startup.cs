using GloveWizard.Api.Configurations;
using GloveWizard.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GloveWizard
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        private readonly IWebHostEnvironment _iWebHostEnvironment;


        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment iWebHostEnvironment)
        {
            _configuration = configuration;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.CreateMapper();
            services.ResolveDependencies();
            services.AddDatabaseContext(_configuration);
            services.AddSwaggerConfig();
            services.AddWebApiConfiguration(MyAllowSpecificOrigins);
            services.AddMvc();
            services.AddJwtConfig(_configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiMiddleware(MyAllowSpecificOrigins);

            if (_iWebHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHsts();
            app.UseStaticFiles();
            app.UseSwaggerConfig();
        }
    }
}
