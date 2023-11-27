using Application.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

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

    private async Task TrySeedAsync()
    {
        List<CpuType> cpuTypes = await SeedCpuTypes();
        List<MemoryType> memoryTypes = await SeedMemoryTypes();
        List<JobStatus> jobStatuses = await SeedJobStatuses();
        List<JobType> jobTypes = await SeedJobTypes();
        List<Project> projects = await SeedProjects();
        await SeedJobSpeeds();

        List<Job> jobs = new();
        for (int i = 0; i < 10; i++)
        {
            jobs.Add(new Job
            {
                Name = $"Seed Job {i}",
                InputFile = $"seed/input/file/path/{i}",
                RuntimeConfigFile = $"seed/runtime/config/file/path/{i}",
                OutputFileDirectory = $"seed/output/file/directory/{i}",
                SupplementalFilesDirectory = $"seed/supplemental/files/directory/{i}",
                CostUsd = Random.Shared.Next(10, 5500),
                CostEstimateUsd = Random.Shared.Next(10, 55000),
                DurationSeconds = Random.Shared.Next(10, 550000),
                Type = jobTypes[Random.Shared.Next(jobTypes.Count)],
                Status = jobStatuses[Random.Shared.Next(jobStatuses.Count)],
                MemoryType = memoryTypes[Random.Shared.Next(memoryTypes.Count)],
                CpuType = cpuTypes[Random.Shared.Next(cpuTypes.Count)],
                Project = projects[Random.Shared.Next(projects.Count)],
                Creator = _context.Users.ToList().FirstOrDefault(),
                Terminator = _context.Users.ToList().FirstOrDefault()
            });
        }
        
        if (!_context.Jobs.Any())
        {
             foreach (Job job in jobs)
             {
                 _context.Jobs.Add(job);
             }
        }
        
        await _context.SaveChangesAsync();
    }
    
    private async Task<List<Project>> SeedProjects()
    {
        List<string> projectNumbers = new() { "221011.22", "221012.22", "221013.22", "221014.22" };
        List<Project> projects = projectNumbers.Select(projectNumber => 
            new Project { Name = projectNumber, Number = projectNumber}).ToList();
        
        if (!_context.Projects.Any())
        {
            foreach (Project project in projects)
            {
                _context.Projects.Add(project);
            }
        }
        await _context.SaveChangesAsync();
        
        return _context.Projects.ToList();
    }

    private async Task<List<CpuType>> SeedCpuTypes()
    {
        Dictionary<string, int> cpuTypesData =
            new() { { "F8s v2", 8 }, { "F32s v2", 32 }, { "FX48mds", 48 }, { "HX176rs", 176 } };
        List<CpuType> cpuTypes = cpuTypesData.Select(cpuType => 
            new CpuType { Name = cpuType.Key, Value = cpuType.Value, }).ToList();
        
        if (!_context.CpuTypes.Any())
        {
            foreach (CpuType cpuType in cpuTypes)
            {
                _context.CpuTypes.Add(cpuType);
            }
        }
        await _context.SaveChangesAsync();
        
        return _context.CpuTypes.ToList();
    }

    private async Task<List<MemoryType>> SeedMemoryTypes()
    {
        List<int> memoryTypeValues = new() { 16, 64, 1008, 1300 };
        List<MemoryType> memoryTypes = memoryTypeValues.Select(memoryTypeValue => 
            new MemoryType { Name = $"{memoryTypeValue} GB RAM", Value = memoryTypeValue }).ToList();
        
        if (!_context.JobSpeeds.Any())
        {
            foreach (MemoryType memoryType in memoryTypes)
            {
                _context.MemoryTypes.Add(memoryType);
            }
        }
        await _context.SaveChangesAsync();
        
        return _context.MemoryTypes.ToList();
    }

    private async Task SeedJobSpeeds()
    {
        List<CpuType> cpuTypes = await SeedCpuTypes();
        List<MemoryType> memoryTypes = await SeedMemoryTypes();
        List<string> speedNames = new() { "Slow", "Medium", "Fast", "Fastest" };
        List<string> skuIds = new() { "DZH318Z0BPWJ/001J", "DZH318Z0BPWJ/001M", "DZH318Z08Q74/002K", "DZH318Z0K1LG/0037" };
        List<JobSpeed> jobSpeeds = speedNames.Select((t, i) => 
            new JobSpeed { Name = t, CpuType = cpuTypes[i], MemoryType = memoryTypes[i], SkuId = skuIds[i], }).ToList();

        if (!_context.JobSpeeds.Any())
        {
            foreach (JobSpeed jobSpeed in jobSpeeds)
            {
                _context.JobSpeeds.Add(jobSpeed);
            }
        }
        await _context.SaveChangesAsync();
        
    }

    private async Task<List<JobStatus>> SeedJobStatuses()
    {
        List<string> jobStatusNames = new() { "Pending", "Running", "Succeeded", "Failed", "Terminated" };
        List<JobStatus> jobStatuses = jobStatusNames.Select(jobStatusName => 
            new JobStatus { Name = jobStatusName }).ToList();
        
        if (!_context.JobSpeeds.Any())
        {
            foreach (JobStatus jobStatus in jobStatuses)
            {
                _context.JobStatuses.Add(jobStatus);
            }
        }
        await _context.SaveChangesAsync();
        
        return _context.JobStatuses.ToList();
    }

    private async Task<List<JobType>> SeedJobTypes()
    {
        List<string> jobTypeNames = new() { "OpenSEES", "OpenSEES-SP", "OpenSEES-MP", "CSI-ETABS", "CSI-SAP2000", "CSI-SAFE" };
        List<JobType> jobTypes = jobTypeNames.Select(jobTypeName => 
            new JobType { Name = jobTypeName }).ToList();
        
        if (!_context.JobTypes.Any())
        {
            foreach (JobType jobType in jobTypes)
            {
                _context.JobTypes.Add(jobType);
            }
        }
        await _context.SaveChangesAsync();
        
        return _context.JobTypes.ToList();
    }
}
