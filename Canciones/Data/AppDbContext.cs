using Microsoft.EntityFrameworkCore;
using ProyectoCanciones.Models;
using System.Collections.Generic;

namespace ProyectoCanciones.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Cancion> Canciones { get; set; }
}
