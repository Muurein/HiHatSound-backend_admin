using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Data;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    public class EditModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public EditModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
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

            var poddportfoliomodel =  await _context.PoddPortfolios.FirstOrDefaultAsync(m => m.Id == id);
            if (poddportfoliomodel == null)
            {
                return NotFound();
            }
            PoddPortfolioModel = poddportfoliomodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PoddPortfolioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoddPortfolioModelExists(PoddPortfolioModel.Id))
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

        private bool PoddPortfolioModelExists(int id)
        {
            return _context.PoddPortfolios.Any(e => e.Id == id);
        }
    }
}
