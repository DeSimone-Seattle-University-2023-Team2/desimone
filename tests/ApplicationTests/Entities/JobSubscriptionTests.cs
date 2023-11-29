using Application.Entities;

namespace ApplicationTests.Entities;

public class JobSubscriptionTests
{
    [Fact]
    public void JobSubscriptionInstantiation_ShouldBeSuccessful()
    {
        // Act
        JobSubscription jobSubscription = new()
        {
            Subscriber = new ApplicationUser(),
            Job = new Job()
        };
        
        // Assert
        Assert.IsType<ApplicationUser>(jobSubscription.Subscriber);
        Assert.IsType<Job>(jobSubscription.Job);
    }
}
