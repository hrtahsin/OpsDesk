namespace OpsDesk.Domain.Constants;

public static class UserRoles
{
    public const string Admin = nameof(Admin);
    public const string ITStaff = nameof(ITStaff);
    public const string Manager = nameof(Manager);
    public const string Employee = nameof(Employee);
    public const string Auditor = nameof(Auditor);

    public static readonly string[] All =
    [
        Admin,
        ITStaff,
        Manager,
        Employee,
        Auditor
    ];
}
