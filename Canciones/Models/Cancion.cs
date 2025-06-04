namespace Canciones.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public double Duracion { get; set; }
        public string Genero { get; set; } = null!;

        public int ArtistaId { get; set; }
        public Artista? Artista { get; set; } = null!;
    }
}
