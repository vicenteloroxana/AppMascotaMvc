using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppMascotaMvc.Models
{
    public class Mascota{
        [Key]
        public Guid MascotaID { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string  Raza{ get; set; }
        public string Caracteristica { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public Guid PropietarioID { get; set; }
        public Propietario Propietario { get; set; }
        public Ficha Ficha { get; set; }        

    }

}