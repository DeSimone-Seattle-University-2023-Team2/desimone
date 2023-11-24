using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class DependencyInjection
{
    private const string ConnectionString = "DefaultConnection";

    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var microsoftClientId = configuration["Authentication:Microsoft:ClientId"];
        var microsoftClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
        var connectionString = configuration["ConnectionStrings:DeSimone:SqlDb"];
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(connectionString,
                $"Connection string '{ConnectionString}' not found.");
        }

        if (string.IsNullOrEmpty(microsoftClientId) || string.IsNullOrEmpty(microsoftClientSecret))
        {
            throw new ArgumentNullException(connectionString, 
                "Microsoft Client credentials not found.");
        }

        services.AddDbContext<JobDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IJobDbContext>(provider => provider.GetRequiredService<JobDbContext>());
        services.AddScoped<JobDbContextInitializer>();
        
        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddEntityFrameworkStores<JobDbContext>();

        services.AddCascadingAuthenticationState();
        services.AddAuthentication()
            .AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = microsoftClientId;
                microsoftOptions.ClientSecret = microsoftClientSecret;
            });

        services.AddScoped<IJobDbContext>(provider => provider.GetRequiredService<JobDbContext>());
  
        services.AddSingleton(TimeProvider.System);
    }
}
