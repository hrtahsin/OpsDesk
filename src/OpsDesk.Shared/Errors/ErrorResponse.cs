namespace OpsDesk.Shared.Errors;

public sealed record ErrorResponse(
    string Code,
    string Message,
    string? TraceId = null,
    IReadOnlyDictionary<string, string[]>? ValidationErrors = null);
