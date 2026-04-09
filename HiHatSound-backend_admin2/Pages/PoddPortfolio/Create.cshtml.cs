using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HiHatSound_backend_admin2.Data;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    public class CreateModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public CreateModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
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
