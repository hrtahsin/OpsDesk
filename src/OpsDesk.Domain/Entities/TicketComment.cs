namespace OpsDesk.Domain.Entities;

public sealed class TicketComment
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public Ticket? Ticket { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public bool IsInternal { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }
}
