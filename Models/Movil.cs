using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppMascotaMvc.Models
{
    public class Movil{
        [Key]
        public Guid MovilID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-M-yyyy}")]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }
        public string Barrio { get; set; }
        public string Zona { get; set; }
        public string  Servicio{ get; set; }
        public int Telefono { get; set; }       

    }

}