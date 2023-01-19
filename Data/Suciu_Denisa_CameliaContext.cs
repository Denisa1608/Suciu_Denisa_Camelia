using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Camelia.Models;

namespace Suciu_Denisa_Camelia.Data
{
    public class Suciu_Denisa_CameliaContext : DbContext
    {
        public Suciu_Denisa_CameliaContext (DbContextOptions<Suciu_Denisa_CameliaContext> options)
            : base(options)
        {
        }

        public DbSet<Suciu_Denisa_Camelia.Models.Supplier> Supplier { get; set; } = default!;

        public DbSet<Suciu_Denisa_Camelia.Models.ProjectforEntity> ProjectforEntity { get; set; }

        public DbSet<Suciu_Denisa_Camelia.Models.Project> Project { get; set; }
    }
}
