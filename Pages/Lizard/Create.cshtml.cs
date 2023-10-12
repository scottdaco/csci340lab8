using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesLizard.Data;

namespace lab8.Pages_Lizard
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesLizard.Data.RazorPagesLizardContext _context;

        public CreateModel(RazorPagesLizard.Data.RazorPagesLizardContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lizard Lizard { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lizard == null || Lizard == null)
            {
                return Page();
            }

            _context.Lizard.Add(Lizard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
