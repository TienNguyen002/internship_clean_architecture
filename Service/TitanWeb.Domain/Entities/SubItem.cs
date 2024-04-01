using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class SubItem : IEntity
{
    public int Id { get; set; }

    public string? TextItem { get; set; }

    public int? ImageId { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
