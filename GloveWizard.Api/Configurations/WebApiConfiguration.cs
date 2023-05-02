using GloveWizard.Api.Configurations;
using Microsoft.AspNetCore.Mvc;
namespace GloveWizard.Configurations
{
    public static class WebApiConfiguration
    {
        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services, string cors)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(cors,
                                  builder =>
                                  {
                                      builder
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .WithExposedHeaders("Content-Disposition");
                                  });
            });

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IApplicationBuilder UseApiMiddleware(this IApplicationBuilder app, string cors)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors(cors);
            app.UseRouting();
            app.UseMiddleware<MiddlewareExpection>();
            app.UseEndpoints(endpoints =>
            endpoints.MapControllers());

            return app;
        }
    }
}
