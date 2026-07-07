using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(user => user.DisplayName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(user => user.CreatedAt)
            .IsRequired();

        builder.HasOne(user => user.Department)
            .WithMany()
            .HasForeignKey(user => user.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(user => user.DepartmentId);
        builder.HasIndex(user => user.IsActive);
    }
}
