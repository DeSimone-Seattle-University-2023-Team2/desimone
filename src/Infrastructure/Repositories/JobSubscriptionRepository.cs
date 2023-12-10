using Application.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobSubscriptionRepository(JobDbContext context) : IJobSubscriptionRepository
{
    public Task<List<JobSubscription>> GetJobSubscriptionsByJobId(int jobId)
    {
        return Task.FromResult(context.JobSubscriptions
            .Include(jobSubscription => jobSubscription.Job)
            .Include(jobSubscription => jobSubscription.Subscriber)
            .ToList());
    }
    
    public Task<JobSubscription> GetJobSubscriptionByJobSubscriptionId(int id)
    {
        return Task.FromResult(context.JobSubscriptions
            .Include(jobSubscription => jobSubscription.Job)
            .Include(jobSubscription => jobSubscription.Subscriber)
            .FirstOrDefault(jobSubscription => jobSubscription.Id == id) ?? throw new KeyNotFoundException($"Job Subscription with id [{id}] does not exist"));
    }

    public async Task CreateJobSubscription(JobSubscription jobSubscription)
    {
        await context.AddAsync(jobSubscription);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteJobSubscription(int id)
    {
        var jobSubscription = await GetJobSubscriptionByJobSubscriptionId(id);
        
        context.Remove(jobSubscription);
        await context.SaveChangesAsync();
    }
}
