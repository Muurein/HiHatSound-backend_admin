using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gallery.Models;
using HiHatSound_backend_admin2.Data;
using Microsoft.AspNetCore.Authorization;

namespace HiHatSound_backend_admin2.Controllers
{
    
    [Route("api/gallery")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gallery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GalleryModel>>> GetGalleries()
        {
            return await _context.Galleries.ToListAsync();
        }

        // GET: api/Gallery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryModel>> GetGalleryModel(int id)
        {
            var galleryModel = await _context.Galleries.FindAsync(id);

            if (galleryModel == null)
            {
                return NotFound();
            }

            return galleryModel;
        }

        // PUT: api/Gallery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryModel(int id, GalleryModel galleryModel)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != galleryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(galleryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Gallery
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GalleryModel>> PostGalleryModel(GalleryModel galleryModel)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Galleries.Add(galleryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGalleryModel", new { id = galleryModel.Id }, galleryModel);
        }

        // DELETE: api/Gallery/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryModel(int id)
        {
            var galleryModel = await _context.Galleries.FindAsync(id);
            if (galleryModel == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(galleryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalleryModelExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
