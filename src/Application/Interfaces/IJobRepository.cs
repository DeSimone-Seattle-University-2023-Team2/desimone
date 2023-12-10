using Application.Entities;

namespace Application.Interfaces;

public interface IJobRepository
{
    public Task<List<Job>> GetJobs();
    public Task<Job> GetJobById(int id);
    public Task CreateOrUpdateJob(Job job);
    public Task DeleteJob(int id);
}
