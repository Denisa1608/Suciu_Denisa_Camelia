namespace Suciu_Denisa_Camelia.Models
{
    public class ProjectforEntity
    {
        public int ID { get; set; }
        public string ProjectforEntityName { get; set; }
        public ICollection<Supplier>? Suppliers { get; set; }
    }
}
