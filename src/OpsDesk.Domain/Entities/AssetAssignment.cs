namespace OpsDesk.Domain.Entities;

public sealed class AssetAssignment
{
    public int Id { get; set; }

    public int AssetId { get; set; }

    public Asset? Asset { get; set; }

    public string AssignedToUserId { get; set; } = string.Empty;

    public string AssignedByUserId { get; set; } = string.Empty;

    public DateTimeOffset AssignedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? ReturnedAt { get; set; }

    public string? ReturnCondition { get; set; }

    public string? Notes { get; set; }
}
