using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppMascotaMvc.Models
{
    public class Ficha{
        [Key]
        public Guid FichaID { get; set; }
        [Display(Name = "Ficha Clinica N° ")]
        public Guid MascotaID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-M-yyyy}")]
        public DateTime Fecha { get; set; }
        public string Fc { get; set; }
        public string Pulso { get; set; }
        public int Fr { get; set; }
        public string  Raza{ get; set; }
        public string  Pelaje{ get; set; }
        public string  SSP{ get; set; }
        public string  Control{ get; set; }
        
        [Display(Name = "T° ")]
        public string  T { get; set; }
        public string Tllc { get; set; }
        public string Mucosa { get; set; }
        public string SignosClinicos { get; set; }
        public string Medicacion { get; set; }
        public string Observacion { get; set; }
        
        public Mascota Mascota { get; set; }
    }

}