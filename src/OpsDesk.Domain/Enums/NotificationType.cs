namespace OpsDesk.Domain.Enums;

public enum NotificationType
{
    TicketUpdated = 1,
    TicketAssigned = 2,
    AssetRequestSubmitted = 3,
    AssetRequestApproved = 4,
    AssetRequestRejected = 5,
    AssetRequestFulfilled = 6,
    WarrantyExpiring = 7,
    OverdueTicket = 8,
    ReportReady = 9
}
