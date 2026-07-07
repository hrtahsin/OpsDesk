using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(location => location.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(location => location.Building)
            .HasMaxLength(100);

        builder.Property(location => location.Floor)
            .HasMaxLength(50);

        builder.Property(location => location.Room)
            .HasMaxLength(50);

        builder.Property(location => location.City)
            .HasMaxLength(100);

        builder.Property(location => location.Province)
            .HasMaxLength(100);

        builder.HasIndex(location => location.Name);
        builder.HasIndex(location => location.IsActive);
    }
}
