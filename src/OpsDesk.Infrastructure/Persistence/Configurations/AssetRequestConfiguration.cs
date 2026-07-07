using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class AssetRequestConfiguration : IEntityTypeConfiguration<AssetRequest>
{
    public void Configure(EntityTypeBuilder<AssetRequest> builder)
    {
        builder.Property(request => request.RequestNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(request => request.RequestedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(request => request.RequestedCategory)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(request => request.Justification)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(request => request.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(request => request.ManagerApproverId)
            .HasMaxLength(450);

        builder.Property(request => request.ITProcessorId)
            .HasMaxLength(450);

        builder.Property(request => request.RejectionReason)
            .HasMaxLength(1000);

        builder.Property(request => request.RowVersion)
            .IsRowVersion();

        builder.HasOne(request => request.Department)
            .WithMany(department => department.AssetRequests)
            .HasForeignKey(request => request.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(request => request.FulfilledAsset)
            .WithMany(asset => asset.FulfilledRequests)
            .HasForeignKey(request => request.FulfilledAssetId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(request => request.RequestedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(request => request.ManagerApproverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(request => request.ITProcessorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(request => request.RequestNumber)
            .IsUnique();

        builder.HasIndex(request => request.Status);
        builder.HasIndex(request => request.RequestedByUserId);
        builder.HasIndex(request => request.DepartmentId);
    }
}
