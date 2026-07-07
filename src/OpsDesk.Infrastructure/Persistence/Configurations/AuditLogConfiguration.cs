using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.Property(log => log.EntityType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(log => log.EntityId)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(log => log.ActionType)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(log => log.Summary)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(log => log.OldValues)
            .HasColumnType("nvarchar(max)");

        builder.Property(log => log.NewValues)
            .HasColumnType("nvarchar(max)");

        builder.Property(log => log.PerformedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(log => log.PerformedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(log => new { log.EntityType, log.EntityId });
        builder.HasIndex(log => log.PerformedByUserId);
        builder.HasIndex(log => log.CreatedAt);
    }
}
