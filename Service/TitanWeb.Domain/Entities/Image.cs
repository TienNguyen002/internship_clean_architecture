namespace TitanWeb.Domain.Entities;

public partial class Image
{
    public int ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Hyperlink { get; set; }

    public bool IsLogo { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<SubItem> SubItems { get; set; } = new List<SubItem>();
}
