using Application.Entities;

namespace ApplicationTests.Entities;

public class JobTypeTests
{
    [Fact]
    public void JobTypeInstantiation_ShouldBeSuccessful()
    {
        // Act
        JobType jobType = new()
        {
            Name = "OpenSEES",
            Jobs = new List<Job>()
        };
        
        // Assert
        Assert.Equal("OpenSEES", jobType.Name);
        Assert.IsType<List<Job>>(jobType.Jobs);
    }
}
