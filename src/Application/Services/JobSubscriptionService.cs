using Application.Entities;
using Application.Interfaces;

namespace Application.Services;

public class JobSubscriptionService
{
    private readonly IJobSubscriptionRepository _jobSubscriptionRepository;

    /** Constructor **/
    public JobSubscriptionService(IJobSubscriptionRepository jobSubscriptionRepository)
    {
        _jobSubscriptionRepository = jobSubscriptionRepository;
    }

    public Task<List<JobSubscription>> GetJobSubscriptionsByJobId(int jobId)
    {
        return _jobSubscriptionRepository.GetJobSubscriptionsByJobId(jobId);
    }

    public Task CreateJobSubscription(JobSubscription jobSubscription)
    {
        return _jobSubscriptionRepository.CreateJobSubscription(jobSubscription);
    }

    public Task DeleteJobSubscription(int id)
    {
        return _jobSubscriptionRepository.DeleteJobSubscription(id);
    }
}
