using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Round
{
    public long Id { get; set; }

    public string Start { get; set; } = null!;

    public string? End { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Station> Stations { get; } = new List<Station>();
}
