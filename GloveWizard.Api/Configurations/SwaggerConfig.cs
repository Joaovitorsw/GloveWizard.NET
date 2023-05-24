using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GloveWizard.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(SwaggerGenOptions =>
            {
                SwaggerGenOptions.OperationFilter<SwaggerDefaultValues>();

                OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                };

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                SwaggerGenOptions.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


                SwaggerGenOptions.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                OpenApiSecurityRequirement openApiSecurityRequirement =
                    new OpenApiSecurityRequirement
                    {
                        { openApiSecurityScheme, new[] { "Bearer" } }
                    };

                SwaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = String.Empty;
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
                options.EnableFilter();
                options.DocumentTitle = "Glove Wizard API";
            });
        }
    }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IConfiguration _configuration;

        public ConfigureSwaggerOptions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", CreateInfoForApiVersion());
        }

        private OpenApiInfo CreateInfoForApiVersion()
        {
            var info = new OpenApiInfo
            {
                Title = _configuration.GetValue<string>("Swagger:Title"),
                Description = _configuration.GetValue<string>("Swagger:Description"),
                Contact = new OpenApiContact
                {
                    Email = "joaovitorswbr@gmail.com",
                    Name = "Software Engineer"
                },
                Version = "v1.0",
            };

            return info;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription.ParameterDescriptions.First(
                    ApiParameterDescription => ApiParameterDescription.Name == parameter.Name
                );

                var routeInfo = description.RouteInfo;

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (routeInfo == null)
                {
                    continue;
                }

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }

    public class SwaggerAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerAuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (
                context.Request.Path.StartsWithSegments("/swagger")
                && !context.User.Identity.IsAuthenticated
            )
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
