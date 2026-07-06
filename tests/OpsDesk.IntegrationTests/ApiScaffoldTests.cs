namespace OpsDesk.IntegrationTests;

public sealed class ApiScaffoldTests
{
    [Fact]
    public void ApiProgram_ShouldBePublicForFutureIntegrationTests()
    {
        Assert.Equal("OpsDesk.Api", typeof(Program).Assembly.GetName().Name);
    }
}
