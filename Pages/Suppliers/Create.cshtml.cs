using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public CreateModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProjectforEntityID"] = new SelectList(_context.Set<ProjectforEntity>(), "ID", "ProjectforEntityName");
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Supplier.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
