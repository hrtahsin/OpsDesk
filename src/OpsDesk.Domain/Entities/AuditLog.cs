using OpsDesk.Domain.Enums;

namespace OpsDesk.Domain.Entities;

public sealed class AuditLog
{
    public int Id { get; set; }

    public string EntityType { get; set; } = string.Empty;

    public string EntityId { get; set; } = string.Empty;

    public AuditActionType ActionType { get; set; }

    public string Summary { get; set; } = string.Empty;

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string PerformedByUserId { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
