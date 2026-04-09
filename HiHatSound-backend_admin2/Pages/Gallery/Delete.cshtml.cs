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
    public class DeleteModel : PageModel
    {
        private readonly HiHatSound_backend_admin2.Data.ApplicationDbContext _context;

        public DeleteModel(HiHatSound_backend_admin2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GalleryModel GalleryModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallerymodel = await _context.Galleries.FirstOrDefaultAsync(m => m.Id == id);

            if (gallerymodel is not null)
            {
                GalleryModel = gallerymodel;

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

            var gallerymodel = await _context.Galleries.FindAsync(id);
            if (gallerymodel != null)
            {
                GalleryModel = gallerymodel;
                _context.Galleries.Remove(GalleryModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
