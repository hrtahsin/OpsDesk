namespace OpsDesk.Shared.Pagination;

public sealed record PagedRequest
{
    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 20;

    public int Skip => (NormalizedPageNumber - 1) * NormalizedPageSize;

    public int NormalizedPageNumber => Math.Max(1, PageNumber);

    public int NormalizedPageSize => Math.Clamp(PageSize, 1, 100);
}
