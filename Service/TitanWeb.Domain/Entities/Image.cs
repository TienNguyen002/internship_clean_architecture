using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Image : IEntity
{
    public int Id { get; set; }

    public string? ImageUrl { get; set; }

    public string? Hyperlink { get; set; }

    public bool IsLogo { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
