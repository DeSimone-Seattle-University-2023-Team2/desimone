using Application.Entities;

namespace ApplicationTests.Entities;

public class JobStatusTests
{
    [Fact]
    public void JobStatusInstantiation_ShouldBeSuccessful()
    {
        // Act
        JobStatus jobStatus = new()
        {
            Name = "Running",
            Jobs = new List<Job>()
        };
        
        // Assert
        Assert.Equal("Running", jobStatus.Name);
        Assert.IsType<List<Job>>(jobStatus.Jobs);
    }
}
