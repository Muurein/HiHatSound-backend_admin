using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gallery.Models;

namespace HiHatSound_backend_admin2.Pages.Gallery
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
        public GalleryModel GalleryModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Galleries.Add(GalleryModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
