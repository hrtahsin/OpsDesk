namespace OpsDesk.Domain.Entities;

public sealed class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Building { get; set; }

    public string? Floor { get; set; }

    public string? Room { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; } = [];

    public ICollection<Asset> Assets { get; set; } = [];
}
