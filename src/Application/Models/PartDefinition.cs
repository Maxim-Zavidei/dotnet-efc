using System.Collections.Generic;

namespace Application.Models
{
    public class PartDefinition : Entity
    {
        public int Cost { get; set; }
        public string Name { get; set; }

        public List<Part> Parts { get; set; }
    }
}