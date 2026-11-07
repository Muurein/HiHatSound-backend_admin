using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;
using Microsoft.AspNetCore.Authorization;

namespace HiHatSound_backend_admin2.Pages.Gallery
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
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
