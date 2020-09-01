using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Entities.Repositories;
using Entities.Interfaces;
using Entities;
using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IRepositoryContext RepositoryContext { get; }

        private const string AngularCorsPolicy = "_angularCorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=BikesDatabase;Trusted_Connection=True;";
            services.AddDbContext<IRepositoryContext, RepositoryContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton(Configuration);
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<IBikeRepository, BikeRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AngularCorsPolicy, builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AngularCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
