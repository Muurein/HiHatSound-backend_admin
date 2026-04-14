using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Data;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Controllers
{
    [Route("api/poddportfolio")]
    [ApiController]
    public class PoddPortfolioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PoddPortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PoddPortfolio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoddPortfolioModel>>> GetPoddPortfolios()
        {
            return await _context.PoddPortfolios.ToListAsync();
        }

        // GET: api/PoddPortfolio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoddPortfolioModel>> GetPoddPortfolioModel(int id)
        {
            var poddPortfolioModel = await _context.PoddPortfolios.FindAsync(id);

            if (poddPortfolioModel == null)
            {
                return NotFound();
            }

            return poddPortfolioModel;
        }

        // PUT: api/PoddPortfolio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoddPortfolioModel(int id, PoddPortfolioModel poddPortfolioModel)
        {
            if (id != poddPortfolioModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(poddPortfolioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoddPortfolioModelExists(id))
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

        // POST: api/PoddPortfolio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PoddPortfolioModel>> PostPoddPortfolioModel(PoddPortfolioModel poddPortfolioModel)
        {
            _context.PoddPortfolios.Add(poddPortfolioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoddPortfolioModel", new { id = poddPortfolioModel.Id }, poddPortfolioModel);
        }

        // DELETE: api/PoddPortfolio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoddPortfolioModel(int id)
        {
            var poddPortfolioModel = await _context.PoddPortfolios.FindAsync(id);
            if (poddPortfolioModel == null)
            {
                return NotFound();
            }

            _context.PoddPortfolios.Remove(poddPortfolioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoddPortfolioModelExists(int id)
        {
            return _context.PoddPortfolios.Any(e => e.Id == id);
        }
    }
}
