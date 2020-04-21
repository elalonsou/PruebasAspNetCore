using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebasAPI_CRUD_EntityFramework.Models;

namespace PruebasAPI_CRUD_EntityFramework.Data
{
    public class PruebasAPI_CRUD_EntityFrameworkContext : DbContext
    {
        public PruebasAPI_CRUD_EntityFrameworkContext (DbContextOptions<PruebasAPI_CRUD_EntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<PruebasAPI_CRUD_EntityFramework.Models.Cancion> Cancion { get; set; }
    }
}
