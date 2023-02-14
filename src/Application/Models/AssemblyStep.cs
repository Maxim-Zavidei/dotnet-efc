using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class AssemblyStep
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Cost { get; set; }

    public virtual ICollection<StationsAssemblyStepss> StationsAssemblyStepsses { get; } = new List<StationsAssemblyStepss>();
}
