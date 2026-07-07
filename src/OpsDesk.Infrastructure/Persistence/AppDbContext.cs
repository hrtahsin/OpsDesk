using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
{
    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Ticket> Tickets => Set<Ticket>();

    public DbSet<TicketComment> TicketComments => Set<TicketComment>();

    public DbSet<TicketAttachment> TicketAttachments => Set<TicketAttachment>();

    public DbSet<TicketActivityLog> TicketActivityLogs => Set<TicketActivityLog>();

    public DbSet<Asset> Assets => Set<Asset>();

    public DbSet<AssetAssignment> AssetAssignments => Set<AssetAssignment>();

    public DbSet<AssetRequest> AssetRequests => Set<AssetRequest>();

    public DbSet<Notification> Notifications => Set<Notification>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        SeedData.AppSeedData.Apply(builder);
    }
}
