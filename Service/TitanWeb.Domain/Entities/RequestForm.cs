namespace TitanWeb.Domain.Entities;

public partial class RequestForm
{
    public int RequestFormId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
