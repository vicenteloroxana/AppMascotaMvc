using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppMascotaMvc.Models;

namespace AppMascotaMvc.Models.ViewModel
{
    public class RolUsuarioViewModel{
        
        public string Id { get; set; }
        public string RolNombre { get; set; }
        public List<string> Usuarios { get; set; }
        public RolUsuarioViewModel()
        {
            Usuarios = new List<string>();
        }
        

    }

}




