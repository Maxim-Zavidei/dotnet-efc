using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class StationsAssemblyStepss
{
    public long Id { get; set; }

    public long? StationId { get; set; }

    public long? AssemblyStepId { get; set; }

    public virtual AssemblyStep? AssemblyStep { get; set; }

    public virtual Station? Station { get; set; }
}
