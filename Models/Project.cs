using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Suciu_Denisa_Camelia.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName 
        { 
            get 
            { 
                return FirstName + " " + LastName; 
            } 
    }

    }
}
