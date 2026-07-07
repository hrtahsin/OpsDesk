using OpsDesk.Domain.Enums;

namespace OpsDesk.Domain.Entities;

public sealed class Asset
{
    public int Id { get; set; }

    public string AssetTag { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public AssetCategory Category { get; set; } = AssetCategory.Other;

    public AssetStatus Status { get; set; } = AssetStatus.Available;

    public string? SerialNumber { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public DateOnly? WarrantyExpiryDate { get; set; }

    public string? AssignedToUserId { get; set; }

    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    public int? LocationId { get; set; }

    public Location? Location { get; set; }

    public string? Notes { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset? RetiredAt { get; set; }

    public byte[] RowVersion { get; set; } = [];

    public ICollection<AssetAssignment> Assignments { get; set; } = [];

    public ICollection<AssetRequest> FulfilledRequests { get; set; } = [];
}
