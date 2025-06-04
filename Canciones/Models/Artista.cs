namespace Canciones.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nacionalidad { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Cancion>? Canciones { get; set; } = new List<Cancion>();
    }
}
