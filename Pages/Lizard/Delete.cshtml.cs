using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesLizard.Data;

namespace lab8.Pages_Lizard
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesLizard.Data.RazorPagesLizardContext _context;

        public DeleteModel(RazorPagesLizard.Data.RazorPagesLizardContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Lizard Lizard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lizard == null)
            {
                return NotFound();
            }

            var lizard = await _context.Lizard.FirstOrDefaultAsync(m => m.Id == id);

            if (lizard == null)
            {
                return NotFound();
            }
            else 
            {
                Lizard = lizard;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lizard == null)
            {
                return NotFound();
            }
            var lizard = await _context.Lizard.FindAsync(id);

            if (lizard != null)
            {
                Lizard = lizard;
                _context.Lizard.Remove(Lizard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
