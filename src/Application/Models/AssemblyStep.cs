using System.Collections.Generic;

namespace Application.Models
{
    public class AssemblyStep : Entity
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }
    }
}