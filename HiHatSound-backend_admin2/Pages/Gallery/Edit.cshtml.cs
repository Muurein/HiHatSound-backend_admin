using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;

namespace HiHatSound_backend_admin2.Pages.Gallery
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public EditModel(Data.ApplicationDbContext context)
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

            var gallerymodel =  await _context.Galleries.FirstOrDefaultAsync(m => m.Id == id);
            if (gallerymodel == null)
            {
                return NotFound();
            }
            GalleryModel = gallerymodel;
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

            _context.Attach(GalleryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryModelExists(GalleryModel.Id))
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

        private bool GalleryModelExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
