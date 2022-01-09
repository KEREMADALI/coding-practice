using System;
using Bussiness.Abstract;
using DataAccess.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ICameraMetadataService CameraMetadataService { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Get Azure Credentials
            var azureUserId = Environment.GetEnvironmentVariable(EnvironmentVariables.AzureUserId, EnvironmentVariableTarget.User);

            if (string.IsNullOrEmpty(azureUserId))
            {
                Console.Error.Write($"Failed to retrieve \"{EnvironmentVariables.AzureUserId}\" from user Environment Variables.");
            }
            else
            {
                Configuration[EnvironmentVariables.AzureUserId] = azureUserId;
            }

            var azurePassword = Environment.GetEnvironmentVariable(EnvironmentVariables.AzurePassword, EnvironmentVariableTarget.User);

            if (string.IsNullOrEmpty(azurePassword))
            {
                Console.Error.Write($"Failed to retrieve \"{EnvironmentVariables.AzurePassword}\" from user User Environment Variables.");
            }
            else
            {
                Configuration[EnvironmentVariables.AzurePassword] = azurePassword;
            }

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
