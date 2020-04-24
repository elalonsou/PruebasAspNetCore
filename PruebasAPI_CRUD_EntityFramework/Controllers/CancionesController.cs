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
            //Primero Buscamos el registro
            //Otra forma          var cancion = await _context.Cancion.FindAsync(id);
            Cancion cancion =  await _context.Canciones.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();

            //Se devuelve el registro borrado.
            //En el CRUD autogenerado por VS hace return sin Ok
            return Ok(cancion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cancion>> PutCancion(int id,[FromBody] Cancion cancion)
        {
            //Comprobamos que el id pasado en la entidad y el id por parametro es el mismo.
            //Si usamos DTO, el Id lo quitariamos del DTO porque no es un dato que se informe en el DTO
            //y al mapearlo con la entidad se lo pondriamos desde el parametro
            if (id != cancion.Id)
            {
                return BadRequest();
            }

            //Ahora agregamos un cambio al contexto agregando la entidad
            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                //Guardamos los cambios controlando hay una excepcion mirar si es porque no existe el id
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CancionExists(int id)
        {
            return _context.Canciones.Any(e => e.Id == id);
        }

    }
}
