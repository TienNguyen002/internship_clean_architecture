using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class SubItem : IEntity
{
    public int Id { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public string? Youtube { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;
}
