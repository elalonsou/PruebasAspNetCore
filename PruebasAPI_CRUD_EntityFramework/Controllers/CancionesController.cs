using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasAPI_CRUD_EntityFramework.Models;
using PruebasAPI_CRUD_EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasAPI_CRUD_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CancionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get api/CancionesManualmente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> Get()
        {
            //Si queremos usar toListAsync() en vez de toList() tenemos que agregar using Microsoft.EntityFrameworkCore;
            return await _context.Canciones.ToListAsync();
        }

        //Get api/CancionesManualmente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
            return await _context.Canciones.Where(x => x.Id==id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion([FromBody] Cancion cancion)
        {
            //Primero se agrega al DbSet la entidad
             _context.Canciones.Add(cancion);
            //Luego se graban los datos en BBDD
            await _context.SaveChangesAsync();
            //Se devuelve que ha ido bien pero se devuelve con la ruta del objeto creado
            return CreatedAtAction("GetCancion", new { id = cancion.Id }, cancion);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cancion>> DeleteCancion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
