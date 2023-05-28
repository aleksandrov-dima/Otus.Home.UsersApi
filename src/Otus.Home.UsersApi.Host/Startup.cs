using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.Home.UsersApi.Core.Abstractions.Repositories;
using Otus.Home.UsersApi.DataAccess;
using Otus.Home.UsersApi.DataAccess.Data;
using Otus.Home.UsersApi.DataAccess.Repositories;
using Otus.Home.UsersApi.Host.Models;

namespace Otus.Home.UsersApi.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMappingProfile));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            
            services.AddScoped<IDbInitializer, EfDbInitializer>();
            
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql(connectionString);
                x.UseSnakeCaseNamingConvention();
                
                x.UseLazyLoadingProxies();
            });
            
            services.AddOpenApiDocument(options =>
            {
                options.Title = "Users API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.DocExpansion = "list";
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            dbInitializer.InitializeDb();
        }
    }
}