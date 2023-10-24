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
    public class WeaponProxiesController : ControllerBase
    {
        private readonly Context _context;

        public WeaponProxiesController(Context context)
        {
            _context = context;
        }

        // GET: api/WeaponProxies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon>>> GetWeaponProxy()
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }

            var weaponProxies = await _context.Weapons.ToListAsync();
            var weapon = weaponProxies.Select(we => new Weapon(we.Id, we.Name, we.DamagePoints, (HeroClassType)we.HeroClassType)).ToList();

            return weapon;
        }

        // GET: api/WeaponProxies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon>> GetWeaponProxy(int id)
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }

            var weaponProxy = await _context.Weapons.FindAsync(id);
            var weapon = new Weapon(weaponProxy.Id, weaponProxy.Name, weaponProxy.DamagePoints, (HeroClassType)weaponProxy.HeroClassType);

            if (weapon == null)
            {
                return NotFound();
            }

            return weapon;
        }

        // PUT: api/WeaponProxies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponProxy(int id, WeaponProxy weaponProxy)
        {
            if (id != weaponProxy.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponProxy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponProxyExists(id))
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

        // POST: api/WeaponProxies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeaponProxy>> PostWeaponProxy(WeaponProxy weaponProxy)
        {
            if (_context.Weapons == null)
            {
                return Problem("Entity set 'Context.WeaponProxy'  is null.");
            }

            _context.Weapons.Add(weaponProxy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponProxy", new { id = weaponProxy.Id }, weaponProxy);
        }

        // DELETE: api/WeaponProxies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponProxy(int id)
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }

            var weaponProxy = await _context.Weapons.FindAsync(id);

            if (weaponProxy == null)
            {
                return NotFound();
            }

            _context.Weapons.Remove(weaponProxy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponProxyExists(int id)
        {
            return (_context.Weapons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
