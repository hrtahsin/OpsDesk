using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class AssetAssignmentConfiguration : IEntityTypeConfiguration<AssetAssignment>
{
    public void Configure(EntityTypeBuilder<AssetAssignment> builder)
    {
        builder.Property(assignment => assignment.AssignedToUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(assignment => assignment.AssignedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(assignment => assignment.ReturnCondition)
            .HasMaxLength(100);

        builder.Property(assignment => assignment.Notes)
            .HasMaxLength(1000);

        builder.HasOne(assignment => assignment.Asset)
            .WithMany(asset => asset.Assignments)
            .HasForeignKey(assignment => assignment.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(assignment => assignment.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(assignment => assignment.AssignedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(assignment => assignment.AssetId);
        builder.HasIndex(assignment => assignment.AssignedToUserId);
        builder.HasIndex(assignment => new { assignment.AssetId, assignment.ReturnedAt });
    }
}
