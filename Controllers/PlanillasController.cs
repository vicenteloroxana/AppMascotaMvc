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
    [Authorize(Roles = "Administrador,Veterinario")]
    [AllowAnonymous]
    public class PlanillasController : Controller
    {
        private readonly MascotaContext _context;
        
        public PlanillasController(MascotaContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(string d)
        {
            var baseDate = DateTime.Today;
            var f=DateTime.Now;
            var propietariosBD = await _context.Turnos.Include(t => t.Propietario).ToListAsync();
            propietariosBD = await _context.Turnos.Where(t => t.Descripcion == d).ToListAsync();
            propietariosBD=propietariosBD.OrderBy(t => t.Hora.TimeOfDay).ToList();
            List<TurnoViewModel> propietarios = new List<TurnoViewModel>();
            
            foreach (var item in propietariosBD)
            {
                propietarios.Add(new TurnoViewModel() 
                {
                    TurnoID = item.TurnoID,
                    PropietarioID = item.PropietarioID,
                    Propietario = item.Propietario,
                    Fecha = item.Fecha,
                    Hora=item.Hora,
                    Descripcion=item.Descripcion
                });
            }
            ViewBag.Descripcion=d;
            return View(propietarios);
            
        }
          
        
        //detalle get
        public async Task<IActionResult> Details(Guid? id, string d)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietarioBD = await _context.Propietarios
                .FirstOrDefaultAsync(p => p.PropietarioID == id);
                
            PropietarioViewModel model= new PropietarioViewModel();    
            model.PropietarioID=propietarioBD.PropietarioID;       
            model.Email=propietarioBD.Email;
            model.Telefono=propietarioBD.Telefono;
            model.Domicilio = propietarioBD.Domicilio;    
            if (propietarioBD == null)
            {
                return NotFound();
            }
            ViewBag.Descripcion=d;
            return View(model);
        }
        //edit get
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietarioBD = await _context.Propietarios.FindAsync(id);
            PropietarioViewModel model= new PropietarioViewModel();   
            model.PropietarioID=propietarioBD.PropietarioID;       
            model.NombrePersona = propietarioBD.NombrePersona;
            model.Apellido= propietarioBD.Apellido;
            model.DNI=propietarioBD.DNI;
            model.Email=propietarioBD.Email;
            model.Telefono=propietarioBD.Telefono;
            model.Domicilio = propietarioBD.Domicilio;
            
            if (propietarioBD == null)
            {
                return NotFound();
            }
            return View(model);
            
        }
        //edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PropietarioID,NombrePersona,Apellido,,DNI,Email,Domicilio,Telefono")] Propietario p)
        {
            string d;
            if (id != p.PropietarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                    var turno= await _context.Turnos.FirstOrDefaultAsync(t=>t.PropietarioID==p.PropietarioID);
                    d=turno.Descripcion;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(p.PropietarioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new {d=d});
            }
            
            return View(p);
        }
        private bool PropietarioExists(Guid id)
        {
            return _context.Propietarios.Any(p => p.PropietarioID == id);
        }
        //delete get
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.Include(t => t.Propietario)
                .FirstOrDefaultAsync(t => t.Propietario.PropietarioID == id);
            TurnoViewModel model= new TurnoViewModel();  
            
            model.TurnoID=turno.TurnoID;       
            model.PropietarioID=turno.PropietarioID;       
            model.Hora=turno.Hora; 
            model.Fecha=turno.Fecha; 
            model.Propietario=turno.Propietario;
            model.Descripcion=turno.Descripcion;
  
            if (turno == null)
            {
                return NotFound();
            }

            return View(model);
        }
        //delete post , 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            var turno= await _context.Turnos.FirstOrDefaultAsync(t=>t.PropietarioID==id);
            var d=turno.Descripcion;
            _context.Propietarios.Remove(propietario);
            

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new {d=d});
        }
        
    }
}    