using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppMascotaMvc.Models
{
    public class Propietario{
    [Key]
    public Guid PropietarioID { get; set; }
    [Display(Name = "Nombre")]
    public string NombrePersona { get; set; }
    public string Apellido { get; set; }
    public int DNI { get; set; }  
    public string Email { get; set; }
    public string Domicilio { get; set; }
    public string Telefono { get; set; }
    public int CantidadMascotasPermitidas { get; set; }
    
    [Display(Name = "Mascotas Permitidas")]
    public List<Mascota> Mascotas { get; set; }
    public List<Turno> Turnos { get; set; }
    

    }
}
