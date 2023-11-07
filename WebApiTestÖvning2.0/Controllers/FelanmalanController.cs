using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTestÖvning2._0.Data;
using WebApiTestÖvning2._0.Model;

namespace WebApiTestÖvning2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FelanmalanController : ControllerBase
    {
        private readonly FelanmälanDbContext _context;

        public FelanmalanController(FelanmälanDbContext context)
        {
            _context = context;
        }

        // GET: api/Felanmalan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Felanmälan>>> GetFelanmalan()
        {
          if (_context.Felanmälan == null)
          {
              return NotFound();
          }
            return await _context.Felanmälan.ToListAsync();
        }

        // GET: api/Felanmalan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Felanmälan>> GetFelanmalan(int id)
        {
          if (_context.Felanmälan == null)
          {
              return NotFound();
          }
            var felanmälan = await _context.Felanmälan.FindAsync(id);

            if (felanmälan == null)
            {
                return NotFound();
            }

            return felanmälan;
        }

        // PUT: api/Felanmälan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFelanmalan(int id, Felanmälan felanmälan)
        {
            if (id != felanmälan.Id)
            {
                return BadRequest();
            }

            _context.Entry(felanmälan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelanmalanExists(id))
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

        // POST: api/Felanmälan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Felanmälan>> PostFelanmalan(Felanmälan felanmälan)
        {
          if (_context.Felanmälan == null)
          {
              return Problem("Entity set 'FelanmälanDbContext.Felanmälan'  is null.");
          }
            _context.Felanmälan.Add(felanmälan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFelanmalan", new { id = felanmälan.Id }, felanmälan);
        }

        // DELETE: api/Felanmälan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFelanmalan(int id)
        {
            if (_context.Felanmälan == null)
            {
                return NotFound();
            }
            var felanmälan = await _context.Felanmälan.FindAsync(id);
            if (felanmälan == null)
            {
                return NotFound();
            }

            _context.Felanmälan.Remove(felanmälan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FelanmalanExists(int id)
        {
            return (_context.Felanmälan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
