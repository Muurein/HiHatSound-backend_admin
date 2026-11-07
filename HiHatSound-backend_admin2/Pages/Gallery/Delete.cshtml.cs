using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;

namespace HiHatSound_backend_admin2.Pages.Gallery
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DeleteModel(Data.ApplicationDbContext context)
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
