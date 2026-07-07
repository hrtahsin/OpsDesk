namespace OpsDesk.Domain.Entities;

public sealed class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string? ManagerUserId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; } = [];

    public ICollection<Asset> Assets { get; set; } = [];

    public ICollection<AssetRequest> AssetRequests { get; set; } = [];
}
