namespace OpsDesk.Domain.Constants;

public static class AuthorizationPolicies
{
    public const string CanManageUsers = nameof(CanManageUsers);
    public const string CanManageTickets = nameof(CanManageTickets);
    public const string CanAssignTickets = nameof(CanAssignTickets);
    public const string CanManageAssets = nameof(CanManageAssets);
    public const string CanApproveAssetRequests = nameof(CanApproveAssetRequests);
    public const string CanViewReports = nameof(CanViewReports);
    public const string CanViewAuditLogs = nameof(CanViewAuditLogs);
}
