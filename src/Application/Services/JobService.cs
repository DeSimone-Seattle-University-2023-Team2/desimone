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

    public List<Job> GetJobs()
    {
        return _jobRepository.GetJobs();
    }
}
