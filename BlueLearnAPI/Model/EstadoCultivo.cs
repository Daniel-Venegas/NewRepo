using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class EstadoCultivo
    {
        [Key]
        public int IdEstadoCultivo { get; set; }
        public required string Descripcion {  get; set; }
    }
}
