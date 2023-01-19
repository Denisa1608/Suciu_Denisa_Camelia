using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Pages.ProjectforEntitys
{
    public class EditModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public EditModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectforEntity ProjectforEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProjectforEntity == null)
            {
                return NotFound();
            }

            var projectforentity =  await _context.ProjectforEntity.FirstOrDefaultAsync(m => m.ID == id);
            if (projectforentity == null)
            {
                return NotFound();
            }
            ProjectforEntity = projectforentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectforEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectforEntityExists(ProjectforEntity.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectforEntityExists(int id)
        {
          return _context.ProjectforEntity.Any(e => e.ID == id);
        }
    }
}
