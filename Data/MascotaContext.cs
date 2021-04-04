using AppMascotaMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AppMascotaMvc.Data
{
    public class MascotaContext : IdentityDbContext
    {
        public MascotaContext(DbContextOptions<MascotaContext> options) : base(options)
        {
            
        }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Movil> Moviles { get; set; }

    }
}
