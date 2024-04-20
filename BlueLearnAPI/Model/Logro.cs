using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class Logro
    {
        [Key]
        public int IdLogro { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime Fecha { get; set; }
        public required int Puntos { get; set; }

    }
}
