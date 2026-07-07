using OpsDesk.Domain.Constants;
using OpsDesk.Domain.Entities;
using OpsDesk.Domain.Enums;

namespace OpsDesk.UnitTests.Domain;

public sealed class DomainModelTests
{
    [Fact]
    public void Ticket_ShouldDefaultToOpenWithMediumPriority()
    {
        var ticket = new Ticket();

        Assert.Equal(TicketStatus.Open, ticket.Status);
        Assert.Equal(TicketPriority.Medium, ticket.Priority);
        Assert.False(ticket.RequiresDueDate);
    }

    [Fact]
    public void Ticket_ShouldRequireDueDate_WhenPriorityIsCritical()
    {
        var ticket = new Ticket
        {
            Priority = TicketPriority.Critical
        };

        Assert.True(ticket.RequiresDueDate);
    }

    [Fact]
    public void Asset_ShouldDefaultToAvailable()
    {
        var asset = new Asset();

        Assert.Equal(AssetStatus.Available, asset.Status);
        Assert.Equal(AssetCategory.Other, asset.Category);
    }

    [Fact]
    public void AssetRequest_ShouldDefaultToSubmitted()
    {
        var request = new AssetRequest();

        Assert.Equal(AssetRequestStatus.Submitted, request.Status);
    }

    [Fact]
    public void UserRoles_ShouldContainExpectedEnterpriseRoles()
    {
        Assert.Contains(UserRoles.Admin, UserRoles.All);
        Assert.Contains(UserRoles.ITStaff, UserRoles.All);
        Assert.Contains(UserRoles.Manager, UserRoles.All);
        Assert.Contains(UserRoles.Employee, UserRoles.All);
        Assert.Contains(UserRoles.Auditor, UserRoles.All);
    }
}
