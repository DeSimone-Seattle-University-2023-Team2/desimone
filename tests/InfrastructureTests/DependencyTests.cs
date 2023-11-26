using System.Reflection;
using NetArchTest.Rules;

namespace InfrastructureTests;

public class DependencyTests
{
    private static readonly Assembly InfrastructureAssembly = Assembly.Load("Infrastructure");

    [Fact] 
    public void Infrastructure_Should_NotHaveDependencyOnPresentation()
    {
        const string presentationNamespace = "Presentation";
        TestResult result = Types.InAssembly(InfrastructureAssembly)
            .ShouldNot().HaveDependencyOn(presentationNamespace)
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
    
    [Fact] 
    public void Infrastructure_Should_HaveDependencyOnApplication()
    {
        const string applicationNamespace = "Application";
        TestResult result = Types.InAssembly(InfrastructureAssembly)
            .That().HaveName("JobDbContext")
            .Or().HaveName("JobDbContextInitializer")
            .Should().HaveDependencyOn(applicationNamespace)
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
}
