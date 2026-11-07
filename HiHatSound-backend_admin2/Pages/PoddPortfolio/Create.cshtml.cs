using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PoddPortfolioModel PoddPortfolioModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PoddPortfolios.Add(PoddPortfolioModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
