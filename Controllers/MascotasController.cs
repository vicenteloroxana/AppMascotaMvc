using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AppMascotaMvc.Data;
using AppMascotaMvc.Models;
using AppMascotaMvc.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks.Sources;
using System.Net;

namespace AppMascotaMvc.Controllers
{
    public class MascotasController : Controller
    {
        private MascotaContext _context;
        
        public MascotasController(MascotaContext context)
        {
            _context= context;
        }
        private bool MascotaExists(Guid id)
        {
            return _context.Mascotas.Any(m=> m.MascotaID == id);
        }
        //INDEX GET
        public async Task<IActionResult> Index(string d, Guid? id)
        {
            var mascotasDB = await _context.Mascotas.Include(m => m.Propietario).ToListAsync();
            mascotasDB = await _context.Mascotas.Where(m => m.Descripcion == d).ToListAsync();
            List<MascotaViewModel> mascotas = new List<MascotaViewModel>();
            
            foreach (var item in mascotasDB)
            {
                mascotas.Add(new MascotaViewModel() 
                {
                    MascotaID = item.MascotaID,
                    PropietarioID = item.PropietarioID,
                    Propietario = item.Propietario,
                    Nombre = item.Nombre,
                    Sexo=item.Sexo,
                    Edad=item.Edad,
                    Raza=item.Raza,
                    Caracteristica=item.Caracteristica,
                    Observacion=item.Observacion,
                    Descripcion=item.Descripcion
                });
            }
            ViewBag.Descripcion=d;
            ViewBag.PropietarioID=id;
            return View(mascotas);
            
            
        }
        //CREATE GET
        public async Task<IActionResult> Create(Guid? id)
        {
            ViewBag.Descripcion= new List<SelectListItem>()
            {
                new SelectListItem(){Text="Atencion Veterinaria", Value="Atencion Veterinaria"},
                new SelectListItem(){Text="Castracion", Value="Castracion"},
            };
            var propietarioBD = await _context.Propietarios
                .FirstOrDefaultAsync(p => p.PropietarioID == id);
            MascotaViewModel mascota = new MascotaViewModel();
            mascota.Propietario=propietarioBD;
            mascota.PropietarioID=propietarioBD.PropietarioID;
            return View(mascota);
        }
        //CREATE POST
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropietarioID,Propietario,Nombre,Sexo,Edad,Raza,Caracteristica,Observacion,Descripcion")] MascotaViewModel m)
        {
            Mascota mascota = new Mascota();
            if (ModelState.IsValid)
            {
                mascota.MascotaID = Guid.NewGuid();
                mascota.Nombre=m.Nombre;
                mascota.Sexo=m.Sexo;
                mascota.Edad=m.Edad;
                mascota.Raza=m.Raza;
                mascota.Caracteristica=m.Caracteristica;
                mascota.Observacion=m.Observacion;
                mascota.Descripcion=m.Descripcion;
                mascota.PropietarioID=m.PropietarioID;
                mascota.Propietario=m.Propietario;
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                ViewBag.PropietarioID=mascota.PropietarioID;
                return RedirectToAction("Index", new {d=mascota.Descripcion, id=mascota.PropietarioID});
            }
            
            return View(m);
        }
        //GET DETALLE
        public async Task<IActionResult> details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaBD = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            MascotaViewModel model= new MascotaViewModel();    
            model.MascotaID=mascotaBD.MascotaID;       
            model.Nombre = mascotaBD.Nombre;
            model.Caracteristica=mascotaBD.Caracteristica;
            model.Observacion = mascotaBD.Observacion;    
            model.Propietario=mascotaBD.Propietario;
            model.PropietarioID=mascotaBD.PropietarioID;
            model.Descripcion=mascotaBD.Descripcion;
            if (mascotaBD == null)
            {
                return NotFound();
            }

            return View(model);
        }
        //EDIT GET
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaBD = await _context.Mascotas.FirstOrDefaultAsync(m => m.MascotaID == id);
            MascotaViewModel model= new MascotaViewModel();   
            model.PropietarioID=mascotaBD.PropietarioID;  
            model.MascotaID=mascotaBD.MascotaID;     
            model.Nombre = mascotaBD.Nombre;
            model.Sexo= mascotaBD.Sexo;
            model.Edad=mascotaBD.Edad;
            model.Raza=mascotaBD.Raza;
            model.Caracteristica=mascotaBD.Caracteristica;
            model.Observacion = mascotaBD.Observacion;
            model.Descripcion=mascotaBD.Descripcion;
            
            ViewBag.Descripcion= new List<SelectListItem>()
            {
                new SelectListItem(){Text="Atencion Veterinaria", Value="Atencion Veterinaria"},
                new SelectListItem(){Text="Castracion", Value="Castracion"},
            };
            if (mascotaBD == null)
            {
                return NotFound();
            }
            return View(model);
            
        }
        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MascotaID,PropietarioID,Nombre,Sexo,Edad,Raza,Descripcion,Caracteristica,Observacion")] Mascota m)
        {
            string d;
            if (id != m.MascotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m);
                    await _context.SaveChangesAsync();
                    var mascota= await _context.Mascotas.FirstOrDefaultAsync(mascota=>mascota.MascotaID==m.MascotaID);
                    d=mascota.Descripcion;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(m.MascotaID))
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
            
            return View(m);
        }
        //GET DELETE
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.Include(m => m.Propietario)
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            MascotaViewModel model= new MascotaViewModel();  
            
            model.MascotaID=mascota.MascotaID;       
            model.PropietarioID=mascota.PropietarioID;       
            model.Propietario=mascota.Propietario;
            model.Nombre=mascota.Nombre; 
            model.Sexo=mascota.Sexo; 
            model.Edad=mascota.Edad; 
            model.Raza=mascota.Raza; 
            model.Caracteristica=mascota.Caracteristica; 
            model.Observacion=mascota.Observacion; 
            model.Descripcion=mascota.Descripcion; 
            
            if (mascota == null)
            {
                return NotFound();
            }

            return View(model);
        }
        //delete post 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            string d =mascota.Descripcion;
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new {d=d});
        }
        
    }
}