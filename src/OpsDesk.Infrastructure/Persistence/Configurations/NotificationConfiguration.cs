using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(notification => notification.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(notification => notification.Type)
            .HasConversion<string>()
            .HasMaxLength(75)
            .IsRequired();

        builder.Property(notification => notification.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(notification => notification.Message)
            .HasMaxLength(2000)
            .IsRequired();

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(notification => notification.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(notification => new { notification.UserId, notification.IsRead });
        builder.HasIndex(notification => notification.CreatedAt);
    }
}
