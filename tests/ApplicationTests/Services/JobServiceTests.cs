using Application.Entities;
using Application.Interfaces;
using Application.Services;

namespace ApplicationTests.Services;

public class JobServiceTests
{
    private readonly Mock<IJobRepository> _mockJobRepository = new();
    private const string TestJobName = "Test Job 1";

    [Fact]
    public void GetJobs_ShouldReturnsJobs()
    {
        // Arrange
        var jobService = new JobService(_mockJobRepository.Object);
        var jobs = new List<Job>
        {
            new() { Id = 1, Name = TestJobName },
        };
        _mockJobRepository.Setup(jobRepo => jobRepo.GetJobs()).Returns(jobs);
        
        // Act
        var result = jobService.GetJobs();
        
        // Assert
        Assert.Single(result);
        Assert.Equal(TestJobName, result[0].Name);
    }
}
