using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Data;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    public class DeleteModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public DeleteModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PoddPortfolioModel PoddPortfolioModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poddportfoliomodel = await _context.PoddPortfolios.FirstOrDefaultAsync(m => m.Id == id);

            if (poddportfoliomodel is not null)
            {
                PoddPortfolioModel = poddportfoliomodel;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poddportfoliomodel = await _context.PoddPortfolios.FindAsync(id);
            if (poddportfoliomodel != null)
            {
                PoddPortfolioModel = poddportfoliomodel;
                _context.PoddPortfolios.Remove(PoddPortfolioModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
