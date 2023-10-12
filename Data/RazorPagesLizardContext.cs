using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesLizard.Data
{
    public class RazorPagesLizardContext : DbContext
    {
        public RazorPagesLizardContext (DbContextOptions<RazorPagesLizardContext> options)
            : base(options)
        {
        }

        public DbSet<Lizard> Lizard { get; set; } = default!;
    }
}
