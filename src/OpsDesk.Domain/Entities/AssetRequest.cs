using OpsDesk.Domain.Enums;

namespace OpsDesk.Domain.Entities;

public sealed class AssetRequest
{
    public int Id { get; set; }

    public string RequestNumber { get; set; } = string.Empty;

    public string RequestedByUserId { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    public AssetCategory RequestedCategory { get; set; } = AssetCategory.Other;

    public string Justification { get; set; } = string.Empty;

    public AssetRequestStatus Status { get; set; } = AssetRequestStatus.Submitted;

    public string? ManagerApproverId { get; set; }

    public DateTimeOffset? ManagerDecisionAt { get; set; }

    public string? ITProcessorId { get; set; }

    public int? FulfilledAssetId { get; set; }

    public Asset? FulfilledAsset { get; set; }

    public DateTimeOffset? FulfilledAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }

    public string? RejectionReason { get; set; }

    public byte[] RowVersion { get; set; } = [];
}
