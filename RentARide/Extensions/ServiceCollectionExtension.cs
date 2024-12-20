﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentARide.Core.Contracts;
using RentARide.Core.Services;
using RentARide.Data;
using RentARide.Infrastructure.Data.Common;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension 
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IAgentService, AgentService>();

            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                 .AddDefaultIdentity<IdentityUser>(options =>

                 { options.SignIn.RequireConfirmedAccount = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                 })
                  .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }


    }
}
