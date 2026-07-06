using OpsDesk.Domain;
using OpsDesk.Shared.Pagination;

namespace OpsDesk.UnitTests;

public sealed class ScaffoldTests
{
    [Fact]
    public void DomainAssemblyReference_ShouldPointToDomainProject()
    {
        Assert.Equal("OpsDesk.Domain", DomainAssemblyReference.Assembly.GetName().Name);
    }

    [Fact]
    public void PagedResult_ShouldCalculateTotalPages()
    {
        var result = PagedResult<int>.Create(new[] { 1, 2 }, pageNumber: 1, pageSize: 2, totalCount: 5);

        Assert.Equal(3, result.TotalPages);
    }
}
