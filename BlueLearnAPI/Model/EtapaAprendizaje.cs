﻿using System.ComponentModel.DataAnnotations;

namespace BlueLearnAPI.Model
{
    public class EtapaAprendizaje
    {
        [Key]
        public int IdEstado { get; set; }
        public required int IdAgricultor {  get; set; }
        public required int IdEtapa {  get; set; }
        public required DateTime FechaInit {  get; set; }
        public required DateTime FechaFin {  get; set; }
        public Agricultores? Agricultores { get; set; }
        public Etapa? Etapa {  get; set; }
    }
}
