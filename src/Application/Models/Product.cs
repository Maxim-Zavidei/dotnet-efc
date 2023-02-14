using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Start { get; set; } = null!;

    public string? End { get; set; }

    public long? RoundId { get; set; }

    public virtual ICollection<Part> Parts { get; } = new List<Part>();

    public virtual Round? Round { get; set; }
}
