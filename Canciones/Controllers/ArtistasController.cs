using Canciones.Data;
using Canciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Canciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
            return await _context.Artistas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtistas), new { id = artista.Id }, artista);
        }
    }
}
