namespace TitanWeb.Domain.Entities;

public partial class SubItem
{
    public int SubItemId { get; set; }

    public string? TextItem { get; set; }

    public int? ImageId { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
