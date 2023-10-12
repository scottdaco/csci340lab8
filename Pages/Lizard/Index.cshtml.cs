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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesLizard.Data.RazorPagesLizardContext _context;

        public IndexModel(RazorPagesLizard.Data.RazorPagesLizardContext context)
        {
            _context = context;
        }

        public IList<Lizard> Lizard { get;set; } = default!;

        [BindProperty(SupportsGet = true)]

        public string? SearchString { get; set; }

        public string? Lname { get; set; }

        

        public async Task OnGetAsync()
{
    // Use LINQ to get list of genres.
    IQueryable<string> genreQuery = from m in _context.Lizard
                                    orderby m.name
                                    select m.name;

    var lizard = from m in _context.Lizard
                 select m;

    if (!string.IsNullOrEmpty(SearchString))
    {
        lizard = lizard.Where(s => s.name.Contains(SearchString));
    }

    if (!string.IsNullOrEmpty(Lname))
    {
        lizard = lizard.Where(x => x.name == Lname);
    }
    Lizard = await lizard.ToListAsync();
}
    }
}
