namespace OpsDesk.Shared.Pagination;

public sealed record PagedResult<T>(
    IReadOnlyCollection<T> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages)
{
    public static PagedResult<T> Create(
        IReadOnlyCollection<T> items,
        int pageNumber,
        int pageSize,
        int totalCount)
    {
        var normalizedPageSize = Math.Max(1, pageSize);
        var totalPages = (int)Math.Ceiling(totalCount / (double)normalizedPageSize);

        return new PagedResult<T>(
            items,
            Math.Max(1, pageNumber),
            normalizedPageSize,
            Math.Max(0, totalCount),
            totalPages);
    }
}
