using System.Reflection;
using NetArchTest.Rules;

namespace PresentationTests;

public class DependencyTests
{
    private static readonly Assembly ApplicationAssembly = Assembly.Load("Presentation");

    [Fact] 
    public void PresentationProgram_Should_HaveDependencyOnApplicationAndInfrastructure()
    {
        const string applicationNamespace = "Application";
        const string infrastructureNamespace = "Infrastructure";
        TestResult result = Types.InAssembly(ApplicationAssembly)
            .That().HaveName("Program")
            .Should().HaveDependencyOnAll(applicationNamespace, infrastructureNamespace)
            .GetResult();
        
        Assert.True(result.IsSuccessful);
    }
}
