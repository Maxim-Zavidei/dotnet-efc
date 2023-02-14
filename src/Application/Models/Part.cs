using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Part
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public long? PartDefinitionId { get; set; }

    public virtual PartDefinition? PartDefinition { get; set; }

    public virtual Product? Product { get; set; }
}
