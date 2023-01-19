using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Suciu_Denisa_Camelia.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Hourlyrate { get; set; }

        [DataType(DataType.Date)] 
        public DateTime ContractDate { get; set; }
        public int? ProjectforEntityID { get; set; }
        public ProjectforEntity? ProjectforEntity { get; set; }
        public int? ProjectID { get; set; }
        public Project? Project { get; set; }
    }
}
