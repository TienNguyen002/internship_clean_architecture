using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class SubItem : IEntity
{
    public int Id { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Linkedin { get; set; }

    public string? Youtube { get; set; }

    public int ItemId { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual Item Item { get; set; } = null!;
}
