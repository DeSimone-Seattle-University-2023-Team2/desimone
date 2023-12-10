using Application.Entities;

namespace Application.Interfaces;

public interface IJobSubscriptionRepository
{
    public Task<List<JobSubscription>> GetJobSubscriptionsByJobId(int jobId);
    public Task<JobSubscription> GetJobSubscriptionByJobSubscriptionId(int id);
    public Task CreateJobSubscription(JobSubscription jobSubscription);
    public Task DeleteJobSubscription(int id);
}
