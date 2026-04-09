using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;
using HiHatSound_backend_admin2.Data;
using Microsoft.AspNetCore.Authorization;

namespace HiHatSound_backend_admin2.Pages.Gallery
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public IndexModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GalleryModel> GalleryModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //check if _context is null FEL PALTS FEL PALTS FEL PALTS MEN KAN VARA BRA KOD ATT KOMMA IHÅG???? ca 21:00 i videon
            // if (_context.Galleries == null)
            // {
            //     //if null, return NotFound
            //     return NotFound();
            // }
            GalleryModel = await _context.Galleries.ToListAsync();
        }
    }
}
