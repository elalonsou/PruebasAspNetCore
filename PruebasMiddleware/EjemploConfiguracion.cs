using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasMiddleware
{
    public class EjemploConfiguracion
    {
        public SeccionPersonalizada SeccionPersonalizada { get; set; }
    }

    public class SeccionPersonalizada
    {
        string _pruebaCampo1;
        string _pruebaCampo2;
        string _pruebaCampo3;

        public string PruebaCampo1 { get => _pruebaCampo1; set => _pruebaCampo1 = value; }
        public string PruebaCampo2 { get => _pruebaCampo2; set => _pruebaCampo2 = value; }
        public string PruebaCampo3 { get => _pruebaCampo3; set => _pruebaCampo3 = value; }
    }


}
