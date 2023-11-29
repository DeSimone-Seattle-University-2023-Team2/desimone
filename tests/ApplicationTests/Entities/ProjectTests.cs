using Application.Entities;

namespace ApplicationTests.Entities;

public class ProjectTests
{
    [Fact]
    public void ProjectInstantiation_ShouldBeSuccessful()
    {
        // Act
        Project memoryType = new()
        { 
            Name = "Test Project",
            Number = "123456.22",
            Jobs = new List<Job>()
        };
        
        // Assert
        Assert.Equal("Test Project", memoryType.Name);
        Assert.Equal("123456.22", memoryType.Number);
        Assert.IsType<List<Job>>(memoryType.Jobs);
    }
}
