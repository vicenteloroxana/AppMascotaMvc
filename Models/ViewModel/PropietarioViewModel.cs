using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppMascotaMvc.Models;

namespace AppMascotaMvc.Models.ViewModel
{
    public class PropietarioViewModel{
        [Key]
        public Guid PropietarioID { get; set; }
        [Display(Name = "Nombre")]
        public string NombrePersona { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }  
        public string Email { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public TurnoViewModel Turno { get; set; }

    }

}





