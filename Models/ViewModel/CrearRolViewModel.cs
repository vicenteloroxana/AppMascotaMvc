using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppMascotaMvc.Models;

namespace AppMascotaMvc.Models.ViewModel
{
    public class CrearRolViewModel{
        [Required]
        [Display(Name="Rol")]
        public string NombreRol { get; set; }
        
        
    }

}