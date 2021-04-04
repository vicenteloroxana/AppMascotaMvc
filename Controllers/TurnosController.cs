using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.Linq;
using AppMascotaMvc.Data;
using AppMascotaMvc.Models;
using AppMascotaMvc.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace AppMascotaMvc.Controllers
{
    [Authorize]
    public class TurnosController : Controller
    {

        private readonly MascotaContext _context;
        
        public TurnosController(MascotaContext context)
        {
            _context = context;
        }
        public IActionResult CrearTurno()
        {
            
            ViewBag.Descripcion= new List<SelectListItem>()
            {
                new SelectListItem(){Text="Atencion Veterinaria", Value="Atencion Veterinaria"},
                new SelectListItem(){Text="Castracion", Value="Castracion"},
            };
            
                return View();
            
                
            
        }
        // public void email(Propietario p){
        //     MailMessage correo = new MailMessage();
        //     correo.From = new MailAddress("p.martinez5315@gmail.com");
        //     correo.To.Add(p.Email);
        //     correo.Subject="Información del turno";
        //     correo.Body= p.Apellido+ System.Environment.NewLine +p.Domicilio;
        //     correo.IsBodyHtml=true;
        //     correo.Priority=MailPriority.Normal;
        //     SmtpClient client = new SmtpClient();
        //     client.Host="smtp.gmail.com";
        //     client.Port=25;
        //     client.EnableSsl=true;
        //     string myCorreo="p.martinez5315@gmail.com";
        //     string clave ="dinamita17";
        //     client.Credentials= new System.Net.NetworkCredential(myCorreo,clave);
        //     client.Send(correo);
        // }
        [HttpPost]
        public async Task<IActionResult> GuardarTurno([Bind("NombrePersona,Apellido,DNI,Telefono,Email,Domicilio,Turno")] PropietarioViewModel propietario)
        {
            
            
            if (ModelState.IsValid)
            {

                //Propietario
                Propietario prop= new Propietario();
                prop.PropietarioID=Guid.NewGuid();
                prop.NombrePersona=propietario.NombrePersona;
                prop.Apellido=propietario.Apellido;
                prop.DNI=propietario.DNI;
                prop.Email=propietario.Email;
                prop.Domicilio=propietario.Domicilio;
                prop.Telefono=propietario.Telefono;
                
                //Turno
                Turno t = new Turno();
                t.TurnoID=Guid.NewGuid();
                t.PropietarioID=prop.PropietarioID;
                t.Fecha=propietario.Turno.Fecha;
                t.Hora=propietario.Turno.Hora;
                t.Descripcion=propietario.Turno.Descripcion;
                
                //Add BD
                _context.Propietarios.Add(prop);
                _context.Turnos.Add(t);
                await _context.SaveChangesAsync();
   
            }
            //vista
            return View("Informacion", propietario);
            
            
        }
    }
}
