using Microsoft.EntityFrameworkCore;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Persistence;

namespace OpsDesk.IntegrationTests.Persistence;

public sealed class PersistenceModelTests
{
    [Fact]
    public void Model_ShouldConfigureRowVersionConcurrencyTokens()
    {
        using var context = CreateContext();

        AssertRowVersion<Ticket>(context);
        AssertRowVersion<Asset>(context);
        AssertRowVersion<AssetRequest>(context);
    }

    [Fact]
    public void Model_ShouldConfigureUniqueAssetTagIndex()
    {
        using var context = CreateContext();

        var asset = context.Model.FindEntityType(typeof(Asset));
        var index = Assert.Single(asset!.GetIndexes(), index =>
            index.Properties.Select(property => property.Name).SequenceEqual([nameof(Asset.AssetTag)]));

        Assert.True(index.IsUnique);
    }

    [Fact]
    public void Model_ShouldConfigureTicketFilterIndexes()
    {
        using var context = CreateContext();

        var ticket = context.Model.FindEntityType(typeof(Ticket));
        var indexNames = ticket!.GetIndexes()
            .Select(index => string.Join(",", index.Properties.Select(property => property.Name)))
            .ToHashSet();

        Assert.Contains(nameof(Ticket.Status), indexNames);
        Assert.Contains(nameof(Ticket.Priority), indexNames);
        Assert.Contains(nameof(Ticket.Category), indexNames);
        Assert.Contains(nameof(Ticket.AssignedToUserId), indexNames);
        Assert.Contains(nameof(Ticket.CreatedByUserId), indexNames);
        Assert.Contains(nameof(Ticket.DepartmentId), indexNames);
        Assert.Contains(nameof(Ticket.CreatedAt), indexNames);
        Assert.Contains(nameof(Ticket.DueDate), indexNames);
    }

    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost,1433;Database=OpsDesk_Test;User Id=sa;Password=Test_password_123!;Encrypt=True;TrustServerCertificate=True;")
            .Options;

        return new AppDbContext(options);
    }

    private static void AssertRowVersion<TEntity>(AppDbContext context)
    {
        var entity = context.Model.FindEntityType(typeof(TEntity));
        var rowVersion = entity!.FindProperty("RowVersion");

        Assert.NotNull(rowVersion);
        Assert.True(rowVersion.IsConcurrencyToken);
        Assert.Equal("rowversion", rowVersion.GetColumnType());
    }
}
