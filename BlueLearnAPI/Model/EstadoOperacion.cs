using System.ComponentModel.DataAnnotations;


namespace BlueLearnAPI.Model
{
    public class EstadoOperacion
    {
        [Key]
        public int IdEstadoOperacion {  get; set; }
        public required string Descripcion {  get; set; }
    }
}
