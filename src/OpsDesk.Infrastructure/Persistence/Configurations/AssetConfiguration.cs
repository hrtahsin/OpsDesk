using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.Property(asset => asset.AssetTag)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(asset => asset.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(asset => asset.Category)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(asset => asset.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(asset => asset.SerialNumber)
            .HasMaxLength(100);

        builder.Property(asset => asset.AssignedToUserId)
            .HasMaxLength(450);

        builder.Property(asset => asset.Notes)
            .HasMaxLength(2000);

        builder.Property(asset => asset.RowVersion)
            .IsRowVersion();

        builder.HasOne(asset => asset.Department)
            .WithMany(department => department.Assets)
            .HasForeignKey(asset => asset.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(asset => asset.Location)
            .WithMany(location => location.Assets)
            .HasForeignKey(asset => asset.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(asset => asset.AssignedToUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(asset => asset.AssetTag)
            .IsUnique();

        builder.HasIndex(asset => asset.SerialNumber);
        builder.HasIndex(asset => asset.Status);
        builder.HasIndex(asset => asset.Category);
        builder.HasIndex(asset => asset.AssignedToUserId);
        builder.HasIndex(asset => asset.DepartmentId);
        builder.HasIndex(asset => asset.WarrantyExpiryDate);
    }
}
