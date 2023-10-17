using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorsController : ControllerBase
    {
        private readonly ArmorContext _context;

        public ArmorsController(ArmorContext context)
        {
            _context = context;
        }

        // GET: api/Armors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Armor>>> GetTodoItems()
        {
          if (_context.Armors == null)
          {
              return NotFound();
          }
            return await _context.Armors.ToListAsync();
        }

        // GET: api/Armors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Armor>> GetArmor(int id)
        {
          if (_context.Armors == null)
          {
              return NotFound();
          }
            var armor = await _context.Armors.FindAsync(id);

            if (armor == null)
            {
                return NotFound();
            }

            return armor;
        }

        // PUT: api/Armors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmor(int id, Armor armor)
        {
            if (id != armor.Id)
            {
                return BadRequest();
            }

            _context.Entry(armor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmorExists(id))
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

        // POST: api/Armors
        [HttpPost]
        public async Task<ActionResult<Armor>> PostArmor(Armor armor)
        {
          if (_context.Armors == null)
          {
              return Problem("Entity set 'ArmorContext.TodoItems'  is null.");
          }
            _context.Armors.Add(armor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmor", new { id = armor.Id }, armor);
        }

        // DELETE: api/Armors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmor(int id)
        {
            if (_context.Armors == null)
            {
                return NotFound();
            }
            var armor = await _context.Armors.FindAsync(id);
            if (armor == null)
            {
                return NotFound();
            }

            _context.Armors.Remove(armor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmorExists(int id)
        {
            return (_context.Armors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
