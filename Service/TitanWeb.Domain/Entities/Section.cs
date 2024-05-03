using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Section : IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? JapaneseTitle { get; set; }

    public string? UrlSlug { get; set; }

    public string? Description { get; set; }

    public string? JapaneseDescription { get; set; }

    public int SectionOrder { get; set; }

    public int? ImageId { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
