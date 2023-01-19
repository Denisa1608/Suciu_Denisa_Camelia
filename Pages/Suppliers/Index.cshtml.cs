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
    public class IndexModel : PageModel
    {
        private readonly Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext _context;

        public IndexModel(Suciu_Denisa_Camelia.Data.Suciu_Denisa_CameliaContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;
        public SupplierData SupplierD { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string EmailSort { get; set; }
        public string ProjectSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {

            EmailSort = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ProjectSort = String.IsNullOrEmpty(sortOrder) ? "project_desc" : "";
           
            CurrentFilter = searchString;
            if (_context.Supplier != null)
            {
                Supplier = await _context.Supplier
                    .Include(b => b.ProjectforEntity)
                    .Include(b => b.Project)
                    .ToListAsync();
            }
                if (!String.IsNullOrEmpty(searchString))
                {
                    SupplierD.Suppliers = SupplierD.Suppliers.Where(s => s.Project.FirstName.Contains(searchString)
                    || s.Project.LastName.Contains(searchString) 
                    || s.Email.Contains(searchString));
                }
                if (id != null)

                switch (sortOrder)
                {
                        case "email_desc": SupplierD.Suppliers = SupplierD.Suppliers.OrderByDescending(s => s.Email); break;
                        case "project_desc": SupplierD.Suppliers = SupplierD.Suppliers.OrderByDescending(s => s.Project.FullName); break;

                }
           }
    }
}
