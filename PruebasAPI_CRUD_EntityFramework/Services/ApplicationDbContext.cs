using Microsoft.EntityFrameworkCore;
using PruebasAPI_CRUD_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasAPI_CRUD_EntityFramework.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cancion> Canciones { get; set; }

        public ApplicationDbContext( DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Para usar Fluent API
            //modelBuilder
            //   .Entity<Planificacion>()
            //   .Property(e => e.TipoPlanificacion)
            //   .HasConversion<string>();

            //modelBuilder.Entity<CalendarioUsuario>().HasKey(p => new { p.CalendarioId, p.UsuarioId });
        }
    }
}
