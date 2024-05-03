using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Button : IEntity
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public string? JapaneseLabel { get; set; }

    public string? UrlSlug { get; set; }

    public bool Status { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
