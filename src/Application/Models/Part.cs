namespace Application.Models
{
    public class Part : Entity
    {
        public Product Product { get; set; }
        public PartDefinition PartDefinition { get; set; }
    }
}