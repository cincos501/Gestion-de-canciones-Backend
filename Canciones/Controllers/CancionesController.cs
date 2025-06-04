using Canciones.Data;
using Canciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Canciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CancionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCanciones()
        {
            return await _context.Canciones.Include(c => c.Artista).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
            var cancion = await _context.Canciones.Include(c => c.Artista).FirstOrDefaultAsync(c => c.Id == id);
            return cancion == null ? NotFound() : Ok(cancion);
        }

        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
            _context.Canciones.Add(cancion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCancion), new { id = cancion.Id }, cancion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(int id, Cancion cancion)
        {
            if (id != cancion.Id) return BadRequest();

            _context.Entry(cancion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancion(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null) return NotFound();

            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
