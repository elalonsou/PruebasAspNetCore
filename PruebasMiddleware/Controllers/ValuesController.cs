﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PruebasMiddleware.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
         private readonly ILogger _logger;
        readonly IOptions<EjemploConfiguracion> _config;

        public ValuesController(IOptions<EjemploConfiguracion> config, ILogger<ValuesController> logger)  
        {  
            _logger = logger;
            _config = config;
        }  

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation($"PRUEBA CONFIGURACION {_config.Value.SeccionPersonalizada.PruebaCampo1}");
            _logger.LogInformation("Se va a lanzar excepcion - Información");
            _logger.LogError("Se va a lanzar excepcion - Error");
            _logger.LogCritical("Se va a lanzar excepcion - Critico");
            throw new NotImplementedException();
            return new string[] { "value1", "value3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
