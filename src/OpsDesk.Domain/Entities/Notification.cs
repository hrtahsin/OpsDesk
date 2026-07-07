using OpsDesk.Domain.Enums;

namespace OpsDesk.Domain.Entities;

public sealed class Notification
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public NotificationType Type { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? ReadAt { get; set; }
}
