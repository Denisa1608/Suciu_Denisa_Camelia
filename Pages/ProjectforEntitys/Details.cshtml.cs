using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Pages.ProjectforEntitys
{
    public class DetailsModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public DetailsModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

      public ProjectforEntity ProjectforEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProjectforEntity == null)
            {
                return NotFound();
            }

            var projectforentity = await _context.ProjectforEntity.FirstOrDefaultAsync(m => m.ID == id);
            if (projectforentity == null)
            {
                return NotFound();
            }
            else 
            {
                ProjectforEntity = projectforentity;
            }
            return Page();
        }
    }
}
