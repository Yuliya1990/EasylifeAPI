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
    public class CleaningTypesController : ControllerBase
    {
        private readonly EasyLifeDBContext _context;

        public CleaningTypesController(EasyLifeDBContext context)
        {
            _context = context;
        }


        // GET: api/CleaningTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CleaningType>>> GetCleaningTypes()
        {
          if (_context.CleaningTypes == null)
          {
              return NotFound();
          }
          var cleaningTypes = await _context.CleaningTypes.ToListAsync();
            return Ok(cleaningTypes);
        }

        /*
        // PUT: api/CleaningTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCleaningType(int id, CleaningType cleaningType)
        {
            if (id != cleaningType.CleaningTypeid)
            {
                return BadRequest();
            }

            _context.Entry(cleaningType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CleaningTypeExists(id))
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

        // POST: api/CleaningTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CleaningType>> PostCleaningType(CleaningType cleaningType)
        {
          if (_context.CleaningTypes == null)
          {
              return Problem("Entity set 'EasyLifeDBContext.CleaningTypes'  is null.");
          }
            _context.CleaningTypes.Add(cleaningType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCleaningType", new { id = cleaningType.CleaningTypeid }, cleaningType);
        }

        // DELETE: api/CleaningTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaningType(int id)
        {
            if (_context.CleaningTypes == null)
            {
                return NotFound();
            }
            var cleaningType = await _context.CleaningTypes.FindAsync(id);
            if (cleaningType == null)
            {
                return NotFound();
            }

            _context.CleaningTypes.Remove(cleaningType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CleaningTypeExists(int id)
        {
            return (_context.CleaningTypes?.Any(e => e.CleaningTypeid == id)).GetValueOrDefault();
        }*/
    }
}
