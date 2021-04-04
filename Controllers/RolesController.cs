using System.Reflection;
using System.Xml.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using AppMascotaMvc.Data;
using AppMascotaMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppMascotaMvc.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AppMascotaMvc.Controllers 
{
[Authorize(Roles = "SuperAdmin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole>gestionRoles;
        private readonly UserManager<IdentityUser>gestionUsuarios;
        
        public RolesController(RoleManager<IdentityRole>gestionRoles, UserManager<IdentityUser> gestionUsuarios)
        {
            this.gestionRoles=gestionRoles;
            this.gestionUsuarios = gestionUsuarios;
        }
        [HttpGet]
        public IActionResult CrearRol(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearRol(CrearRolViewModel model){
            if(ModelState.IsValid){
                IdentityRole identityRole=new IdentityRole
                {
                    Name=model.NombreRol
                };
                IdentityResult result= await gestionRoles.CreateAsync(identityRole);
                if(result.Succeeded){
                    return RedirectToAction("GetRoles");

                }
                foreach (IdentityError error in result.Errors){
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult GetRoles() {
            var roles = gestionRoles.Roles;
            return View(roles);
        }
        [HttpGet]
        [Route("Roles/RolUsuario")]
        public async Task< IActionResult> RolUsuario(string id)
        {
            var rol = await gestionRoles.FindByIdAsync(id);
            ViewBag.Nombre=rol.Name;
            var model = new RolUsuarioViewModel
            {
                Id = rol.Id,
                RolNombre = rol.Name
                
            };
            //model.Usuarios=new List<string>();
            foreach (var user in gestionUsuarios.Users)
            {
                if (await gestionUsuarios.IsInRoleAsync(user, rol.Name)) {
                    model.Usuarios.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpGet]
        [Route("Roles/AddRolUsuario")]
        public async Task<IActionResult> AddRolUsuario(string rolId)
        {
            ViewBag.roleId = rolId;
            var role = await gestionRoles.FindByIdAsync(rolId);
            if (role == null) { 
                ViewBag.ErrorMessage = $"Rol con el id {rolId} no fue encontrado";
                
            }
            var model = new List<UsuarioRolViewModel>();
            foreach (var user in gestionUsuarios.Users) 
            {
                var usuarioRolModel = new UsuarioRolViewModel
                {
                    UsuarioId = user.Id,
                    UsuarioEmail = user.UserName
                };
                if (await gestionUsuarios.IsInRoleAsync(user, role.Name))
                {
                    usuarioRolModel.EstaSeleccionado = true;
                }
                else {
                    usuarioRolModel.EstaSeleccionado = false;
                }
                model.Add(usuarioRolModel);
            }
            return View(model);
        }

        [HttpPost]
        [Route("Roles/AddRolUsuario")]
        public async Task<IActionResult> AddRolUsuario(List<UsuarioRolViewModel> model , string rolId)
        {
            
            var rol = await gestionRoles.FindByIdAsync(rolId);
            
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el id {rolId} no fue encontrado";
                return View("Error");
            }

            for (int i = 0;i<model.Count;i++)
            {
                var user = await gestionUsuarios.FindByIdAsync(model[i].UsuarioId);
                IdentityResult result = null;
                if (model[i].EstaSeleccionado && !(await gestionUsuarios.IsInRoleAsync(user, rol.Name)))
                {
                    result = await gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstaSeleccionado && await gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    result = await gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);

                }
                else {
                    continue;
                }
                if (result.Succeeded) 
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else {
                        return RedirectToAction("RolUsuario", new { Id = rolId });
                    }
                
                }
                
            }
            
            return RedirectToAction("RolUsuario", new { Id = rolId });
        }



        

        
        
        
    }
}