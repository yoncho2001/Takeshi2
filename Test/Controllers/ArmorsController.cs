using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Takeshi.Models;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorsController : ControllerBase
    {
        private readonly Context _context;

        public ArmorsController(Context context)
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
            var armorProxies =  await _context.Armors.ToListAsync();
            var armors = armorProxies.Select(ap => new Armor(ap.Id, ap.Name, ap.ArmorPoints)).ToList();

            return armors;
        }

        // GET: api/Armors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Armor>> GetArmor(int id)
        {
          if (_context.Armors == null)
          {
              return NotFound();
          }
            var armorProxy = await _context.Armors.FindAsync(id);
            var armor = new Armor(armorProxy.Id, armorProxy.Name, armorProxy.ArmorPoints);

            if (armor == null)
            {
                return NotFound();
            }

            return armor;
        }

        // PUT: api/Armors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmor(int id, ArmorProxy armor)
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
        public async Task<ActionResult<Armor>> PostArmor(ArmorProxy armor)
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
