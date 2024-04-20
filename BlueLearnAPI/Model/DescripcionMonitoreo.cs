using System.ComponentModel.DataAnnotations;


namespace BlueLearnAPI.Model
{
    public class DescripcionMonitoreo
    {
        [Key]
        public int IdDescripcionMonitoreo { get; set; }
        public required string Variable { get; set; }   
        public required string UnidadMedida { get; set; }
    }
}
