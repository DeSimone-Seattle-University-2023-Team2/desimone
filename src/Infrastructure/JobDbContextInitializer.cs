using Application.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<JobDbContextInitializer>();

        await initializer.InitialiseAsync();

        await initializer.SeedAsync();
    }
}

public class JobDbContextInitializer
{
    private readonly ILogger<JobDbContextInitializer> _logger;
    private readonly JobDbContext _context;

    public JobDbContextInitializer(ILogger<JobDbContextInitializer> logger, JobDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Jobs.Any())
        {
            _context.Jobs.Add(new Job
            {
                Name = "First Seed Job",
            });

            await _context.SaveChangesAsync();
        }
    }
}