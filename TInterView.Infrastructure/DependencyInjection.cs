using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TInterView.Domain.Repositories;
using TInterView.Infrastructure.Data;
using TInterView.Infrastructure.Repositories;

namespace TInterView.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string? connectionString = null)
    {
        // Here you can register your infrastructure services, e.g., DbContext, Repositories, etc.
       
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAppTaskRepository, AppTaskRepository>();
        return services;
    }
}
