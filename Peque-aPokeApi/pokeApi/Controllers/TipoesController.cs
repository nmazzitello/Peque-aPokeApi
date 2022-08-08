using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokeApi.Data;
using pokeApi.Models;

namespace pokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoesController : ControllerBase
    {
        private readonly pokeApiContext _context;

        public TipoesController(pokeApiContext context)
        {
            _context = context;
        }

        // GET: api/Tipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipo()
        {
          if (_context.Tipo == null)
          {
              return NotFound();
          }
            return await _context.Tipo.ToListAsync();
        }

        // GET: api/Tipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> GetTipo(int id)
        {
          if (_context.Tipo == null)
          {
              return NotFound();
          }
            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        // PUT: api/Tipoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, Tipo tipo)
        {
            if (id != tipo.id)
            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        // POST: api/Tipoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipo>> PostTipo(Tipo tipo)
        {
          if (_context.Tipo == null)
          {
              return Problem("Entity set 'pokeApiContext.Tipo'  is null.");
          }
            _context.Tipo.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo", new { id = tipo.id }, tipo);
        }

        // DELETE: api/Tipoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo(int id)
        {
            if (_context.Tipo == null)
            {
                return NotFound();
            }
            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoExists(int id)
        {
            return (_context.Tipo?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
