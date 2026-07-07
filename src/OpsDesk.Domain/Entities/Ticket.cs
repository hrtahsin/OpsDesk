using OpsDesk.Domain.Enums;

namespace OpsDesk.Domain.Entities;

public sealed class Ticket
{
    public int Id { get; set; }

    public string TicketNumber { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TicketCategory Category { get; set; } = TicketCategory.Other;

    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    public TicketStatus Status { get; set; } = TicketStatus.Open;

    public string CreatedByUserId { get; set; } = string.Empty;

    public string? AssignedToUserId { get; set; }

    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    public int? LocationId { get; set; }

    public Location? Location { get; set; }

    public DateTimeOffset? DueDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset? ResolvedAt { get; set; }

    public DateTimeOffset? ClosedAt { get; set; }

    public string? ResolutionSummary { get; set; }

    public byte[] RowVersion { get; set; } = [];

    public ICollection<TicketComment> Comments { get; set; } = [];

    public ICollection<TicketAttachment> Attachments { get; set; } = [];

    public ICollection<TicketActivityLog> ActivityLogs { get; set; } = [];

    public bool RequiresDueDate => Priority == TicketPriority.Critical;
}
