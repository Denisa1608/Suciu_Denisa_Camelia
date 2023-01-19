using System.Security.Policy;

namespace Suciu_Denisa_Camelia.Models.ViewModels
{
    public class ProjectforEntityIndexData
    {
        public IEnumerable<ProjectforEntity> ProjectforEntitys { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
