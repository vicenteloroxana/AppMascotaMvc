using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMascotaMvc.Models.ViewModel
{
    public class UsuarioRolViewModel
    {
        public string UsuarioId { get; set; }
        public bool EstaSeleccionado { get; set; }
        // public string UsuarioIdNombre { get; set; }
        public string UsuarioEmail { get; set; }
    }
}
