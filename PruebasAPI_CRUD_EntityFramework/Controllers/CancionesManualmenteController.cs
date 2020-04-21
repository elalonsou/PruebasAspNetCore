using Microsoft.AspNetCore.Mvc;
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
    public class CancionesManualmenteController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CancionesManualmenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get api/CancionesManualmente
        [HttpGet]
        public  ActionResult<IEnumerable<Cancion>> Get()
        {
            return _context.Canciones.ToList();
        }
    }
}
