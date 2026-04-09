using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Data;
using HiHatSound_backend_admin2.Models;
using Microsoft.AspNetCore.Authorization;

namespace HiHatSound_backend_admin2.Pages.PoddPortfolio
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public IndexModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
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
