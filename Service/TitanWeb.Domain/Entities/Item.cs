using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Item : IEntity
{
    public int Id { get; set; }

    public string? BoldTitle { get; set; }

    public string? JapaneseBoldTitle { get; set; }

    public string? Title { get; set; }

    public string? JapaneseTitle { get; set; }

    public string? UrlSlug { get; set; }

    public string? SubTitle { get; set; }

    public string? JapaneseSubTitle { get; set; }

    public string? ShortDescription { get; set; }

    public string? JapaneseShortDescription { get; set; }

    public string? Description { get; set; }

    public string? JapaneseDescription { get; set; }

    public string? Address { get; set; }

    public string? TelNumber { get; set; }

    public string? InfoGmail { get; set; }

    public string? InfoGmail2 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? ImageId { get; set; }

    public int? SectionId { get; set; }

    public int? ButtonId { get; set; }

    public int? CategoryId { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual Button? Button { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Image? Image { get; set; }

    public virtual Section? Section { get; set; }

    public virtual ICollection<SubItem> SubItems { get; set; } = new List<SubItem>();
}
