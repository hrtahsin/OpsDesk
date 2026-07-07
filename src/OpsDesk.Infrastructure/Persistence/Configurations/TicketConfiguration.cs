using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.Persistence.Configurations;

public sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(ticket => ticket.TicketNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ticket => ticket.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(ticket => ticket.Description)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(ticket => ticket.Category)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ticket => ticket.Priority)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ticket => ticket.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ticket => ticket.CreatedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(ticket => ticket.AssignedToUserId)
            .HasMaxLength(450);

        builder.Property(ticket => ticket.ResolutionSummary)
            .HasMaxLength(2000);

        builder.Property(ticket => ticket.RowVersion)
            .IsRowVersion();

        builder.HasOne(ticket => ticket.Department)
            .WithMany(department => department.Tickets)
            .HasForeignKey(ticket => ticket.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ticket => ticket.Location)
            .WithMany(location => location.Tickets)
            .HasForeignKey(ticket => ticket.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(ticket => ticket.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(ticket => ticket.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(ticket => ticket.TicketNumber)
            .IsUnique();

        builder.HasIndex(ticket => ticket.Status);
        builder.HasIndex(ticket => ticket.Priority);
        builder.HasIndex(ticket => ticket.Category);
        builder.HasIndex(ticket => ticket.AssignedToUserId);
        builder.HasIndex(ticket => ticket.CreatedByUserId);
        builder.HasIndex(ticket => ticket.DepartmentId);
        builder.HasIndex(ticket => ticket.CreatedAt);
        builder.HasIndex(ticket => ticket.DueDate);
    }
}
