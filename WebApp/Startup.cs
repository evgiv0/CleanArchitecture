using DataAccess;
using DataAccess.Interfaces;
using DomainServices.Implementation;
using DomainServices.Interfaces;
using Infrastructure.Implementation;
using Infrastructure.Interfaces.Integrations;
using Infrastructure.Interfaces.WebApp;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UseCases;
using UseCases.Order.Commands.CreateOrder;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //Domain
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            //Infrastructure
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddDbContext<IDbContext, AppDbContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("CleanArchitecture")));

            //Application
            services.AddMediatR(typeof(CreateOrderCommand));

            //Framework
            services.AddControllers();
            services.AddAutoMapper(typeof(MapperProfile));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
