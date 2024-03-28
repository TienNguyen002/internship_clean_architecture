﻿namespace TitanWeb.Domain.Entities;

public partial class Button
{
    public int ButtonId { get; set; }

    public string? Label { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
