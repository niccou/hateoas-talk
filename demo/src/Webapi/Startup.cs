using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebApi.Core.Configuration;
using WebApi.Repository.Configuration;
using WebApi.Swagger;

namespace WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json")
                .UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Hateoas Sample Api";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebApi v2");
            });

            app.UseCors(_ => _.AllowAnyOrigin().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddWebApiCoreConfiguration()
                .AddWebApiRepositoryConfiguration();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddControllers();
            services.AddSwaggerConfiguration();
        }
    }
}