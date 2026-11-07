using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
