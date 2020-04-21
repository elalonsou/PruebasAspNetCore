using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasAPI_CRUD_EntityFramework.Models
{
    public class Cancion
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public double Duracion { get; set; }

        public string Artista { get; set; }
    }
}
