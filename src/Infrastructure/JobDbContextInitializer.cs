using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<JobDbContextInitialiser>();

        await initializer.InitialiseAsync();

        await initializer.SeedAsync();
    }
}

public class JobContextInitializer
{
    
}