using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
{
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
        builder.Property(attachment => attachment.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(attachment => attachment.StoredFileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(attachment => attachment.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(attachment => attachment.StoragePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(attachment => attachment.UploadedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.HasOne(attachment => attachment.Ticket)
            .WithMany(ticket => ticket.Attachments)
            .HasForeignKey(attachment => attachment.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(attachment => attachment.UploadedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(attachment => attachment.TicketId);
        builder.HasIndex(attachment => attachment.UploadedByUserId);
    }
}
