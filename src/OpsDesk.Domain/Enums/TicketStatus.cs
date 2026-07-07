namespace OpsDesk.Domain.Enums;

public enum TicketStatus
{
    Open = 1,
    InProgress = 2,
    WaitingForUser = 3,
    WaitingForApproval = 4,
    Resolved = 5,
    Closed = 6,
    Cancelled = 7
}
