using Application.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobRepository(JobDbContext context) : IJobRepository
{
    public Task<List<Job>> GetJobs()
    {
        return Task.FromResult(context.Jobs
            .Include(job => job.Project)
            .Include(job => job.Creator)
            .Include(job => job.Status)
            .Include(job => job.Type)
            .Include(job => job.CpuType)
            .Include(job => job.MemoryType)
            .ToList());
    }

    public Task<Job> GetJobById(int id)
    {
        return Task.FromResult(context.Jobs
            .Include(job => job.Project)
            .Include(job => job.Creator)
            .Include(job => job.Status)
            .Include(job => job.Type)
            .Include(job => job.CpuType)
            .Include(job => job.MemoryType)
            .FirstOrDefault(job => job.Id == id) ?? throw new KeyNotFoundException($"Job with id [{id}] does not exist"));
    }

    public async Task CreateOrUpdateJob(Job job)
    {
        if (!job.Id.HasValue)
        {
            await context.AddAsync(job);
        }
        else
        {
            context.Update(job);
        }
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteJob(int id)
    {
        var job = await GetJobById(id);
        
        context.Remove(job);
        await context.SaveChangesAsync();
    }
}
