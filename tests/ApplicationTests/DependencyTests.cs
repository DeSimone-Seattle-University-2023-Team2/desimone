using System.Reflection;
using NetArchTest.Rules;

namespace ApplicationTests;

public class DependencyTests
{
    private static readonly Assembly ApplicationAssembly = Assembly.Load("Application");

    [Fact] 
    public void Application_Should_NotHaveDependencyOnInfrastructure()
    {
        const string infrastructureNamespace = "Infrastructure";
        TestResult result = Types.InAssembly(ApplicationAssembly)
            .ShouldNot().HaveDependencyOn(infrastructureNamespace)
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
    
    [Fact] 
    public void Application_Should_NotHaveDependencyOnPresentation()
    {
        const string presentationNamespace = "Presentation";
        TestResult result = Types.InAssembly(ApplicationAssembly)
            .ShouldNot().HaveDependencyOn(presentationNamespace)
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
    
    [Fact] 
    public void EntityBasedClasses_Should_BeSealedClasses()
    {
        const string baseEntityName = "Entity";
        const string entitiesNamespace = "Application.Entities";
        TestResult result = Types.InAssembly(ApplicationAssembly)
            .That().ResideInNamespace(entitiesNamespace)
            .And().DoNotHaveNameMatching(baseEntityName)
            .Should().BeSealed()
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
}
