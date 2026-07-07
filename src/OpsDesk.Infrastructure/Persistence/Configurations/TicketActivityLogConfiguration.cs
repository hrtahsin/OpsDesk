using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class TicketActivityLogConfiguration : IEntityTypeConfiguration<TicketActivityLog>
{
    public void Configure(EntityTypeBuilder<TicketActivityLog> builder)
    {
        builder.Property(log => log.Action)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(log => log.OldValue)
            .HasMaxLength(500);

        builder.Property(log => log.NewValue)
            .HasMaxLength(500);

        builder.Property(log => log.PerformedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.HasOne(log => log.Ticket)
            .WithMany(ticket => ticket.ActivityLogs)
            .HasForeignKey(log => log.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(log => log.PerformedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(log => log.TicketId);
        builder.HasIndex(log => log.PerformedByUserId);
        builder.HasIndex(log => log.CreatedAt);
    }
}
