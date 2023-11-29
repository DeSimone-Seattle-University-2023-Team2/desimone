using Application.Entities;

namespace ApplicationTests.Entities;

public class EntityTests
{
    private class ExtendedEntity : Entity;
    
    [Fact]
    public void Entity_ShouldBeAbstract()
    {
        // Assert
        Assert.True(typeof(Entity).IsAbstract);
    }
    
    [Fact]
    public void ExtendedEntityClass_ShouldHaveEntityProperties()
    {
        var timestamp = DateTime.UtcNow;
        ExtendedEntity extendedEntity = new()
        {
            Id = 0, 
            CreatedAt = timestamp, 
            UpdatedAt = timestamp
        };
        
        // Assert
        Assert.Equal(0, extendedEntity.Id);
        Assert.Equal(timestamp, extendedEntity.CreatedAt);
        Assert.Equal(timestamp, extendedEntity.UpdatedAt);
    }
}
