using Application.Entities;

namespace ApplicationTests.Entities;

public class JobSpeedTests
{
    [Fact]
    public void JobSpeedInstantiation_ShouldBeSuccessful()
    {
        // Act
        JobSpeed jobSpeed = new()
        {
            Name = "Test Job Speed",
            SkuId = "DZH318Z0BPWJ/001J",
            MemoryType = new MemoryType(),
            CpuType = new CpuType(),
            Jobs = new List<Job>()
        };
        
        // Assert
        Assert.Equal("Test Job Speed", jobSpeed.Name);
        Assert.Equal("DZH318Z0BPWJ/001J", jobSpeed.SkuId);
        Assert.IsType<MemoryType>(jobSpeed.MemoryType);
        Assert.IsType<CpuType>(jobSpeed.CpuType);
        Assert.IsType<List<Job>>(jobSpeed.Jobs);
    }
}
