﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public DeleteModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);

            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }
            var project = await _context.Project.FindAsync(id);

            if (project != null)
            {
                Project = project;
                _context.Project.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
