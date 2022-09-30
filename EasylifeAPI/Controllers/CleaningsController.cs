using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasylifeAPI;

namespace EasylifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningsController : ControllerBase
    {
        private readonly EasyLifeApiDBContext _context;

        public CleaningsController(EasyLifeApiDBContext context)
        {
            _context = context;
        }

        // GET: api/Cleanings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cleaning>>> GetCleanings()
        {
            var allCleanings = await _context.Cleanings.ToListAsync();
            return Ok(allCleanings);
        }

        // GET: api/Cleanings/5
      /*  [HttpGet("{id}")]
        public async Task<ActionResult<Cleaning>> GetCleaning(int id)
        {
            var cleaning = await _context.Cleanings.FindAsync(id);

            if (cleaning == null)
            {
                return NotFound();
            }

            return cleaning;
        }

        // PUT: api/Cleanings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCleaning(int id, Cleaning cleaning)
        {
            if (id != cleaning.Cleaningid)
            {
                return BadRequest();
            }

            _context.Entry(cleaning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CleaningExists(id))
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

        // POST: api/Cleanings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cleaning>> PostCleaning(Cleaning cleaning)
        {
            _context.Cleanings.Add(cleaning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCleaning", new { id = cleaning.Cleaningid }, cleaning);
        }

        // DELETE: api/Cleanings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaning(int id)
        {
            var cleaning = await _context.Cleanings.FindAsync(id);
            if (cleaning == null)
            {
                return NotFound();
            }

            _context.Cleanings.Remove(cleaning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CleaningExists(int id)
        {
            return _context.Cleanings.Any(e => e.Cleaningid == id);
        }*/
    }
}
