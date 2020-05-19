using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PruebaConfiguracionASP.NET_Core.Models;

namespace PruebaConfiguracionASP.NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class PruebasConfiguracionController : ControllerBase
    {
        IConfiguration _configuration;
        readonly ModoInyeccionDependenciasOptions _modoInyeccionOption;

        public PruebasConfiguracionController(IConfiguration configuration, IOptions<ModoInyeccionDependenciasOptions> modoInyeccionOption)
        {
            _configuration = configuration;
            _modoInyeccionOption = modoInyeccionOption.Value;
        }

        [HttpGet("PruebaOrden")]
        public object GetConfigOrden()
        {
            //return Ok(new { _configuration.GetSection("PruebasOrden:Valor1").Value  });

            return Ok( _configuration["PruebasOrden:Valor1"]  + "       " + 
                        _configuration["PruebasOrden:Valor2"] + "       " + 
                        _configuration["PruebasOrden:Valor3"] + "\n" +
                        _configuration["SeccionSoloDevelopment:Valor1"]);

        }


        [HttpGet("PruebaJsonPersonalizado")]
        public object GetConfigJsonPersonalizado()
        {
            return Ok("Valor obtenido de configPersonalizada.json : " + _configuration["ValorJsonPersonalizado"]);
        }

        [HttpGet("PruebaOpciones")]
        public object GetOpciones()
        {
            ModoBindingOptions modoBinding;

            modoBinding =  _configuration.GetSection("PruebasOptions:Binding").Get<ModoBindingOptions>();
            return Ok($"{JsonSerializer.Serialize(_modoInyeccionOption)} \n {JsonSerializer.Serialize(modoBinding)}");
        }


        [HttpGet("PruebaArgumento")]
        public object GetArgumentos()
        {
            return Ok(_configuration["Argumento1"] + "\n" + _configuration["ConsolaSeccion:ArgumentoA"] + "\n" + _configuration["ConsolaSeccion:ArgumentoB"]);
        }

        [HttpGet("PruebaSecretos")]
        public object GetSecretos()
        {
            return Ok( _configuration["SeccionSecretos:ClaveSecreto"]);
        }
    }
}