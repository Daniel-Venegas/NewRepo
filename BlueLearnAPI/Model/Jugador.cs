using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class Jugador
    {
        [Key]
        public int IdJugador {  get; set; }
        public required int Puntaje { get; set; }
        public required int Nivel {  get; set; }
        
        
    }
}
