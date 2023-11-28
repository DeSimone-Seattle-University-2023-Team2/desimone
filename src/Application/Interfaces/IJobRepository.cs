using Application.Entities;

namespace Application.Interfaces;

public interface IJobRepository
{
    public List<Job> GetJobs();
    public Job GetJobById(int id);
    public void CreateOrUpdateJob(Job job);
    public void DeleteJob(int id);
}
