using Application.Entities;

namespace ApplicationTests.Entities;

public class CpuTypeTests
{
    [Fact]
    public void CpuTypeInstantiation_ShouldBeSuccessful()
    {
        // Arrange
        List<JobSpeed> speeds = new() { new JobSpeed { Id = 0, Name = "Fast" } };
        CpuType cpuType = new() { Name = "HX176rs", Value = 176, JobSpeeds = speeds };

        // Assert
        Assert.Equal("HX176rs", cpuType.Name);
        Assert.Equal(176, cpuType.Value);
        Assert.Equal(speeds, cpuType.JobSpeeds);
    }
}
