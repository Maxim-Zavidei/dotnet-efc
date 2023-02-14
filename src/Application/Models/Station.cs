using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Station
{
    public long Id { get; set; }

    public long? RoundId { get; set; }

    public string Position { get; set; } = null!;

    public virtual Round? Round { get; set; }

    public virtual ICollection<StationsAssemblyStepss> StationsAssemblyStepsses { get; } = new List<StationsAssemblyStepss>();
}
