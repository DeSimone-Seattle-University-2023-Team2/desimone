using Application.Entities;
using Application.Interfaces;
using Application.Services;

namespace ApplicationTests.Services;

public class JobServiceTests
{
    private readonly Mock<IJobRepository> _mockJobRepository = new();
    private const string TestJobName = "Test Job 1";

    [Fact]
    public async Task GetJobs_ShouldReturnsJobs()
    {
        // Arrange
        var jobService = new JobService(_mockJobRepository.Object);
        var jobs = new List<Job>
        {
            new() { Id = 1, Name = TestJobName },
        };
        
        _mockJobRepository.Setup(jobRepo => jobRepo.GetJobs()).Returns(Task.FromResult(jobs));
        
        // Act
        var result = await jobService.GetJobs();
        
        // Assert
        Assert.Single(result);
        Assert.Equal(TestJobName, result[0].Name);
    }

    [Fact]
    public async Task GetJobById_ShouldReturnJobWhenExists()
    {
        // Arrange
        var jobService = new JobService(_mockJobRepository.Object);
        var jobs = new List<Job>
        {
            new() { Id = 1, Name = TestJobName },
            new() { Id = 2, Name = TestJobName },
        };
        
        _mockJobRepository
            .Setup(jobRepo => jobRepo.GetJobById(It.IsAny<int>()))
            .Returns((int id) => Task.FromResult(jobs.Find(j => j.Id == id) ?? throw new KeyNotFoundException($"Job with id [{id}] does not exist")));
        
        // Act
        var result = await jobService.GetJobById(1);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }
    
    [Fact]
    public async Task GetJobById_ShouldThrowErrorWhenDoesntExist()
    {
        // Arrange
        var jobService = new JobService(_mockJobRepository.Object);
        var jobs = new List<Job>
        {
            new() { Id = 1, Name = TestJobName }
        };
        
        _mockJobRepository
            .Setup(jobRepo => jobRepo.GetJobById(It.IsAny<int>()))
            .Returns((int id) => Task.FromResult(jobs.Find(job => job.Id == id) ?? throw new KeyNotFoundException($"Job with id [{id}] does not exist")));
        
        // Act
        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(async () => await jobService.GetJobById(2));
    }
}
