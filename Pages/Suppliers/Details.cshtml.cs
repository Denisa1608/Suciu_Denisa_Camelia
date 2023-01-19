using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public DetailsModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

      public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.ID == id);

            if (supplier == null)
            {
                return NotFound();
            }
            else 
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}
