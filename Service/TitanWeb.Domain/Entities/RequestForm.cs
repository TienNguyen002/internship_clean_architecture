using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Entities;

public partial class RequestForm : IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
