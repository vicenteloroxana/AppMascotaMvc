using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Collections.Specialized;
using System.Reflection;
using System.Xml.Schema;
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
    
    public class MovilesController : Controller
    {
        private readonly MascotaContext _context;

        public MovilesController(MascotaContext context)
        {
            _context = context;
        }
        private bool FichaExists(Guid id)
        {
            return _context.Fichas.Any(f=> f.FichaID == id);
        }
        //CREATE GET 
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {   
            return View();
        }
        //CREATE POST
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fecha,Hora,Barrio,Zona,Servicio,Telefono")] Movil m)
        {
            
            if (ModelState.IsValid)
            {
                m.MovilID = Guid.NewGuid();
                
                _context.Moviles.Add(m);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home" );
            }
            
            return View(m);
        }
        //Busqueda Movil
        [AllowAnonymous]
        public async Task<MovilList> getMoviles(string zona)
        {
            MovilList movilesList = new MovilList();
            List<MovilViewModel> movilesVM = new List<MovilViewModel>();   
            
            var movilesDB = await (from mov in   _context.Moviles
                            where mov.Zona.Contains(zona)
                            select mov).ToListAsync();
            

            foreach (var item in movilesDB)
            {
                movilesVM.Add(new MovilViewModel() {
                    MovilID = item.MovilID,
                    Fecha = item.Fecha,
                    Hora = item.Hora,
                    Barrio = item.Barrio,
                    Servicio = item.Servicio,
                    Zona = item.Zona,
                    Telefono = item.Telefono
                });
            }
            movilesList.Moviles=movilesVM;

             return movilesList;
         }

    }    
}    