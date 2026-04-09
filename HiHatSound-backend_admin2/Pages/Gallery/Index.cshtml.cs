using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;
using HiHatSound_backend_admin2.Data;

namespace HiHatSound_backend_admin2.Pages.Gallery
{
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
            GalleryModel = await _context.Galleries.ToListAsync();
        }
    }
}
