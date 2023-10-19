using System.Diagnostics;
using desimone.Pages;
using Moq;
using Xunit;

namespace desimone.Tests.Pages;

public class ErrorTests
{
    private readonly ErrorModel _errorModel = new(Mock.Of<ILogger<ErrorModel>>());

    [Fact]
    public void TestOnGetExpectValidErrorModelState()
    {
        Activity activity = new Activity("activity");
        activity.Start();
        _errorModel.OnGet();
        activity.Stop();
        Assert.Equal(true, _errorModel.ModelState.IsValid);
        Assert.Equal(true, _errorModel.ShowRequestId);
    }
}