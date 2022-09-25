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
    public class CleaningComponentsController : ControllerBase
    {
        private readonly EasyLifeDBContext _context;

        public CleaningComponentsController(EasyLifeDBContext context)
        {
            _context = context;
        }

        

        // GET: api/CleaningComponents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CleaningComponent>>> GetCleaningComponents()
        {
            return await _context.CleaningComponents.ToListAsync();
        }

        //


        // GET: api/CleaningComponents/5
        [HttpGet("{cleaningid}")]
        public async Task<ActionResult<IEnumerable<CleaningComponent>>> GetCleaningComponents(int? cleaningid)
        {
           if(cleaningid != null)
            {
                var cleaningComponentsByCleaningType = from cleaningComponent in _context.CleaningComponents
                                                       where cleaningComponent.TypeComponents.Any(typeComponent => typeComponent.Typeid==cleaningid)
                                                       select cleaningComponent;
                return Ok(await cleaningComponentsByCleaningType.ToListAsync());

            }

            return Ok(await _context.CleaningComponents.ToListAsync());
        }


        /*

        // PUT: api/CleaningComponents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCleaningComponent(int id, CleaningComponent cleaningComponent)
        {
            if (id != cleaningComponent.CleaningComponentsid)
            {
                return BadRequest();
            }

            _context.Entry(cleaningComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CleaningComponentExists(id))
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


        // POST: api/CleaningComponents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CleaningComponent>> PostCleaningComponent(CleaningComponent cleaningComponent)
        {
            _context.CleaningComponents.Add(cleaningComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCleaningComponent", new { id = cleaningComponent.CleaningComponentsid }, cleaningComponent);
        }

        // DELETE: api/CleaningComponents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaningComponent(int id)
        {
            var cleaningComponent = await _context.CleaningComponents.FindAsync(id);
            if (cleaningComponent == null)
            {
                return NotFound();
            }

            _context.CleaningComponents.Remove(cleaningComponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CleaningComponentExists(int id)
        {
            return _context.CleaningComponents.Any(e => e.CleaningComponentsid == id);
        }
        */
    }
}
