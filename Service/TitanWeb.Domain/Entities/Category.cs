using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class Category : IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? UrlSlug { get; set; }

    public string Locale { get; set; }

    public virtual ICollection<RequestForm> RequestForms { get; set; } = new List<RequestForm>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
