using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Takeshi.Models;
using Test.Models;

namespace Takeshi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotionProxiesController : ControllerBase
    {
        private readonly Context _context;

        public PotionProxiesController(Context context)
        {
            _context = context;
        }

        // GET: api/PotionProxies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Potion>>> GetPotions()
        {
            if (_context.Potions == null)
            {
                return NotFound();
            }

            var potionProxies = await _context.Potions.ToListAsync();
            var potion = potionProxies.Select(po => new Potion(po.Id, po.Name, (HeroField)po.AffectingField, po.AffectingValue)).ToList();

            return potion;
        }

        // GET: api/PotionProxies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Potion>> GetPotionProxy(int id)
        {
            if (_context.Potions == null)
            {
                return NotFound();
            }
            var potionProxy = await _context.Potions.FindAsync(id);
            var potion = new Potion(potionProxy.Id, potionProxy.Name, (HeroField)potionProxy.AffectingField, potionProxy.AffectingValue);

            if (potion == null)
            {
                return NotFound();
            }

            return potion;
        }

        // PUT: api/PotionProxies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPotionProxy(int id, PotionProxy potionProxy)
        {
            if (id != potionProxy.Id)
            {
                return BadRequest();
            }

            _context.Entry(potionProxy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PotionProxyExists(id))
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

        // POST: api/PotionProxies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PotionProxy>> PostPotionProxy(PotionProxy potionProxy)
        {
            if (_context.Potions == null)
            {
                return Problem("Entity set 'Context.Potions'  is null.");
            }

            _context.Potions.Add(potionProxy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPotionProxy", new { id = potionProxy.Id }, potionProxy);
        }

        // DELETE: api/PotionProxies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePotionProxy(int id)
        {
            if (_context.Potions == null)
            {
                return NotFound();
            }

            var potionProxy = await _context.Potions.FindAsync(id);

            if (potionProxy == null)
            {
                return NotFound();
            }

            _context.Potions.Remove(potionProxy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PotionProxyExists(int id)
        {
            return (_context.Potions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
