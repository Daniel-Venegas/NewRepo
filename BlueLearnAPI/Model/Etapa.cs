using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class Etapa
    {
        [Key]
        public int IdEtapa { get; set; } 
        public required String Descripcion {  get; set; }
    }
}
