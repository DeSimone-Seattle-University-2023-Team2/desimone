using Application.Entities;

namespace ApplicationTests.Entities;

public class MemoryTypeTests
{
    [Fact]
    public void MemoryTypeInstantiation_ShouldBeSuccessful()
    {
        // Act
        MemoryType memoryType = new()
        {
            Name = "1300 GB RAM",
            Value = 1300,
            JobSpeeds = new List<JobSpeed>()
        };
        
        // Assert
        Assert.Equal("1300 GB RAM", memoryType.Name);
        Assert.Equal(1300, memoryType.Value);
        Assert.IsType<List<JobSpeed>>(memoryType.JobSpeeds);
    }
}
