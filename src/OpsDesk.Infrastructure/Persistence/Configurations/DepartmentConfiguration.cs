using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(department => department.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(department => department.Code)
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(department => department.ManagerUserId)
            .HasMaxLength(450);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(department => department.ManagerUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(department => department.Code)
            .IsUnique();

        builder.HasIndex(department => department.IsActive);
    }
}
