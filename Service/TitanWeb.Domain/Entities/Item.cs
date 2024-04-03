using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Item : IEntity
{
    public int Id { get; set; }

    public string? BoldTitle { get; set; }

    public string? Title { get; set; }

    public string? UrlSlug { get; set; }

    public string? SubTitle { get; set; }

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? TelNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? ImageId { get; set; }

    public int? ButtonId { get; set; }

    public virtual Button? Button { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<SubItem> SubItems { get; set; } = new List<SubItem>();
}
