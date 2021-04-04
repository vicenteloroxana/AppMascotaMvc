using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMascotaMvc.Data;
using AppMascotaMvc.Models;
using AppMascotaMvc.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
namespace AppMascotaMvc.Controllers
{
    [Authorize(Roles = "Veterinario")]
    public class FichasController : Controller
    {
        private readonly MascotaContext _context;

        public FichasController(MascotaContext context)
        {
            _context = context;
        }
        private bool FichaExists(Guid id)
        {
            return _context.Fichas.Any(f=> f.FichaID == id);
        }
        //CREATE GET 
        public IActionResult Create(Guid? id)
        {   
            
            var model = 
                from mas in _context.Mascotas
                where mas.MascotaID == id
                select mas.MascotaID;
                // select new {
                //     MascotaID=mas.MascotaID,
                //     Descripcion=mas.Descripcion
                // };
                    // Mascota = mas.Mascota 
            var ficha = model.First();   
            FichaViewModel nFicha = new FichaViewModel();
            nFicha.MascotaID=ficha;
            nFicha.Fecha=DateTime.Today;
            // nFicha.Descripcion=ficha.Descripcion;
            // model.MascotaID=consultaMascota;
            return View(nFicha);
        }
        //CREATE POST
        [HttpPost]
        public async Task<IActionResult> CreateFicha([Bind("MascotaID,Fecha,Pelaje,Mucosa,SignosClinicos")] Ficha f)
        {
            
            if (ModelState.IsValid)
            {
                f.FichaID = Guid.NewGuid();
                
                _context.Fichas.Add(f);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Mascotas" ,new {d="Atencion Veterinaria"});
            }
            
            return View(f);
        }
        //GET DETALLE
        public async Task<IActionResult> details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaBD = await _context.Fichas
                .FirstOrDefaultAsync(f => f.MascotaID == id);
            FichaViewModel model= new FichaViewModel(); 
            model.FichaID=fichaBD.FichaID;   
            model.MascotaID=fichaBD.MascotaID;       
            // model.Fecha = fichaBD.Fecha;
            model.Pelaje=fichaBD.Pelaje;
            model.Mucosa = fichaBD.Mucosa;    
            model.SignosClinicos=fichaBD.SignosClinicos;
            // model.Mascota=fichaBD.Mascota;
            if (fichaBD == null)
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
     
            
            var fichaBD = await  _context.Fichas.FirstOrDefaultAsync(f => f.FichaID == id);
            FichaViewModel model= new FichaViewModel();   
            model.FichaID=fichaBD.FichaID;       
            model.MascotaID = fichaBD.MascotaID;
            model.Pelaje= fichaBD.Pelaje;
            model.SignosClinicos=fichaBD.SignosClinicos;
            model.Mucosa=fichaBD.Mucosa;
            
            if (fichaBD == null)
            {
                return NotFound();
            }
            return View(model);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FichaID,MascotaID,Pelaje,Mucosa,SignosClinicos")] Ficha f)
        {
            
            if (id != f.FichaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Fichas.Update(f);
                    await _context.SaveChangesAsync();
                    // var ficha= await _context.Fichas.FirstOrDefaultAsync(ficha=>ficha.FichaID==f.FichaID);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaExists(f.FichaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new {id=f.MascotaID});
            }
            
            return View(f);
        }
        //GET DELETE
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas.Include(f => f.Mascota)
                .FirstOrDefaultAsync(f => f.FichaID == id);
            FichaViewModel model= new FichaViewModel();  
            
            model.FichaID=ficha.FichaID;       
            model.MascotaID=ficha.MascotaID;       
            model.Mascota=ficha.Mascota;
            model.Fecha=ficha.Fecha; 
            model.Pelaje=ficha.Pelaje; 
            model.SignosClinicos=ficha.SignosClinicos; 
            model.Mucosa=ficha.Mucosa; 
            
             
            
            if (ficha == null)
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
            var ficha = await _context.Fichas.FindAsync(id);
            
            _context.Fichas.Remove(ficha);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Mascotas" ,new {d="Atencion Veterinaria"});
        }


    }    
    
    
}    