using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Models;
using Microsoft.AspNetCore.Authorization;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PoddPortfolioModel> PoddPortfolioModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PoddPortfolioModel = await _context.PoddPortfolios.ToListAsync();
        }
    }
}
