using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class PartDefinition
{
    public long Id { get; set; }

    public long Cost { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; } = new List<Part>();
}
