using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        builder.Property(comment => comment.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(comment => comment.Body)
            .HasMaxLength(4000)
            .IsRequired();

        builder.HasOne(comment => comment.Ticket)
            .WithMany(ticket => ticket.Comments)
            .HasForeignKey(comment => comment.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(comment => comment.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(comment => comment.TicketId);
        builder.HasIndex(comment => comment.UserId);
        builder.HasIndex(comment => comment.IsInternal);
    }
}
