using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasAPI_CRUD_EntityFramework.Data;
using PruebasAPI_CRUD_EntityFramework.Models;

namespace PruebasAPI_CRUD_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesAutogeneradoController : ControllerBase
    {
        private readonly PruebasAPI_CRUD_EntityFrameworkContext _context;

        public CancionesAutogeneradoController(PruebasAPI_CRUD_EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/Canciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCancion()
        {
            return await _context.Cancion.ToListAsync();
        }

        // GET: api/Canciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
            var cancion = await _context.Cancion.FindAsync(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }

        // PUT: api/Canciones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(int id, Cancion cancion)
        {
            if (id != cancion.Id)
            {
                return BadRequest();
            }

            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
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

        // POST: api/Canciones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
            _context.Cancion.Add(cancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancion", new { id = cancion.Id }, cancion);
        }

        // DELETE: api/Canciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cancion>> DeleteCancion(int id)
        {
            var cancion = await _context.Cancion.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Cancion.Remove(cancion);
            await _context.SaveChangesAsync();

            return cancion;
        }

        private bool CancionExists(int id)
        {
            return _context.Cancion.Any(e => e.Id == id);
        }
    }
}
