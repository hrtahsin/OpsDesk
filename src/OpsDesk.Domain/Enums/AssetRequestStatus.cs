namespace OpsDesk.Domain.Enums;

public enum AssetRequestStatus
{
    Submitted = 1,
    ManagerApproved = 2,
    Rejected = 3,
    ITProcessing = 4,
    Fulfilled = 5,
    Cancelled = 6
}
