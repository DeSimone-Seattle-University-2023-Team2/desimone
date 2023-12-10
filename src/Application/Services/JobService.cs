using Application.Entities;
using Application.Interfaces;

namespace Application.Services;

public class JobService
{
    private readonly IJobRepository _jobRepository;

    /** Constructor **/
    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public Task<List<Job>> GetJobs()
    {
        return _jobRepository.GetJobs();
    }

    public Task<Job> GetJobById(int id)
    {
        return _jobRepository.GetJobById(id);
    }

    public Task CreateOrUpdateJob(Job job)
    {
        return _jobRepository.CreateOrUpdateJob(job);
    }

    public Task DeleteJob(int id)
    {
        return _jobRepository.DeleteJob(id);
    }
}
