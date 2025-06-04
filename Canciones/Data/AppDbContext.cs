using Canciones.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Canciones.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cancion> Canciones { get; set; }
    }
}
