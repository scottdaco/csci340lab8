using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesLizard.Data;

namespace lab8.Pages_Lizard
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesLizard.Data.RazorPagesLizardContext _context;

        public EditModel(RazorPagesLizard.Data.RazorPagesLizardContext context)
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

            var lizard =  await _context.Lizard.FirstOrDefaultAsync(m => m.Id == id);
            if (lizard == null)
            {
                return NotFound();
            }
            Lizard = lizard;
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

            _context.Attach(Lizard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LizardExists(Lizard.Id))
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

        private bool LizardExists(int id)
        {
          return (_context.Lizard?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
