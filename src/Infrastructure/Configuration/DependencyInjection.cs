using Application.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class DependencyInjection
{
    private const string SqlDbConnectionString = "ConnectionStrings:DeSimone:SqlDb";
    private const string MicrosoftClientId = "Authentication:Microsoft:ClientId";
    private const string MicrosoftClientSecret = "Authentication:Microsoft:ClientSecret";

    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
       
        AddDatabaseServices(services, configuration);
        AddIdentityServices(services, configuration);
        services.AddSingleton(TimeProvider.System);
    }

    private static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[SqlDbConnectionString];
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(connectionString,
                $"Connection string '{SqlDbConnectionString}' not found.");
        }
        services.AddDbContext<JobDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IJobDbContext>(provider => provider.GetRequiredService<JobDbContext>());
        services.AddScoped<JobDbContextInitializer>();
        services.AddTransient<IJobRepository, JobRepository>();
    }
    
    private static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        var microsoftClientId = configuration[MicrosoftClientId];
        var microsoftClientSecret = configuration[MicrosoftClientSecret];
        
        if (string.IsNullOrEmpty(microsoftClientId) || string.IsNullOrEmpty(microsoftClientSecret))
        {
            throw new ArgumentNullException(microsoftClientSecret, 
                "Microsoft Client credentials not found.");
        }

        services.AddCascadingAuthenticationState();

        services.AddAuthentication()
        .AddMicrosoftAccount(microsoftOptions =>
        {
            microsoftOptions.ClientId = microsoftClientId;
            microsoftOptions.ClientSecret = microsoftClientSecret;
        });
        
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();
        
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<JobDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
    }
}
