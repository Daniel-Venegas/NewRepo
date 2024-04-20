using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class Temporadas
    {
        [Key]
        public int IdTemporada { get; set; }
        public required string Temporada {  get; set; }
    }
}
