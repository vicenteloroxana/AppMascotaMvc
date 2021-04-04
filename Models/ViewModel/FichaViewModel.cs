using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppMascotaMvc.Models;

namespace AppMascotaMvc.Models.ViewModel
{
    public class FichaViewModel{
        public Guid FichaID { get; set; }
        [Display(Name = "Ficha")]
        public Guid MascotaID { get; set; }
        public Mascota Mascota { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-M-yyyy}")]
        public DateTime Fecha { get; set; }
        public string  Pelaje{ get; set; }
        public string  Descripcion{ get; set; }

        public string Mucosa { get; set; }
        [Display(Name = "Signos Clinicos")]
        public string SignosClinicos { get; set; }
    }
}    