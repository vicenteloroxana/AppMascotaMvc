using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMascotaMvc.Models
{
    public class Turno{
        [Key]
        public Guid TurnoID { get; set; }
        public Guid PropietarioID { get; set; }
        public Propietario Propietario { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-M-yyyy}")]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }
        public string Observacion { get; set; }
        public bool Atendido { get; set; }
        public String Descripcion { get; set; }
    }
    
    


}