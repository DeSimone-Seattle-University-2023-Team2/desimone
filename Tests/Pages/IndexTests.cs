using desimone.Pages;
using Moq;
using Xunit;

namespace desimone.Tests.Pages;

public class IndexTests
{
    private readonly IndexModel _indexModel = new(Mock.Of<ILogger<IndexModel>>());

    [Fact]
    public void TestOnGetExpectValidIndexModelState()
    {
        _indexModel.OnGet();
        
        Assert.Equal(true, _indexModel.ModelState.IsValid);
    }
}