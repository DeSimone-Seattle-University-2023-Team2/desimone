using Application.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobRepository(JobDbContext context) : IJobRepository
{
    public List<Job> GetJobs()
    {
        return context.Jobs
            .Include(job => job.Project)
            .Include(job => job.Creator)
            .Include(job => job.Status)
            .Include(job => job.Type)
            .Include(job => job.CpuType)
            .Include(job => job.MemoryType)
            .ToList();
    }

    public Job GetJobById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateOrUpdateJob(Job job)
    {
        throw new NotImplementedException();
    }

    public void DeleteJob(int id)
    {
        throw new NotImplementedException();
    }
}
