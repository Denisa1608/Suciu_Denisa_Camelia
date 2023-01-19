using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Data;
using Suciu_Denisa_Camelia.Models;
using Suciu_Denisa_Camelia.Models.ViewModels;

namespace Suciu_Denisa_Camelia.Pages.ProjectforEntitys
{
    public class IndexModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public IndexModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

        public IList<ProjectforEntity> ProjectforEntity { get;set; } = default!;
        public ProjectforEntityIndexData ProjectforEntityData { get; set; }
        public int ProjectforEntityID { get; set; }
        public int SupplierID { get; set; }
        public async Task OnGetAsync(int? id, int? supplierID)
        {
            ProjectforEntityData = new ProjectforEntityIndexData(); 
            ProjectforEntityData.ProjectforEntitys = await _context.ProjectforEntity
                .Include(i => i.Suppliers)
                .ThenInclude(c => c.Project)
                .OrderBy(i => i.ProjectforEntityName)
                .ToListAsync();
            if (id != null) 
            { 
                ProjectforEntityID = id.Value; 
                ProjectforEntity projectforentity = ProjectforEntityData.ProjectforEntitys
                    .Where(i => i.ID == id.Value).Single(); 
                ProjectforEntityData.Suppliers = projectforentity.Suppliers; 
            }
        }
    }
}
