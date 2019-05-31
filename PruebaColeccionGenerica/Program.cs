using System;

namespace PoCColeccionGenerica
{
    class Program
    {
        static void Main(string[] args)
        {
            DiccionarioRecorribleGenerico<int, string> dicc = new DiccionarioRecorribleGenerico<int, string>();
            dicc.Añadir(1, "Hola 1");
            dicc.Añadir(2, "Hola 2");
            dicc.Añadir(3, "Hola 3");

            bool fin = false;

            if (dicc.Cantidad() != 0)
            {
                dicc.MoverPrimero();
                while (!fin)
                {
                    Console.WriteLine($"Elemento Actual: {dicc.ObtenerActual()}");

                    if (dicc.EsUltimo())
                    {
                        fin = true;
                    }
                    else
                    {
                        dicc.MoverSiguiente();
                    }
                }
                Console.WriteLine($"Obteniendo elemento por clave 2: {dicc.ObtenerValorPorClave(2)}");
                Console.WriteLine($"Obteniendo elemento mediante Indexer 3: {dicc[3]}");

                Console.WriteLine("-------- Probando Iteracion con Yield  -----------\n");
                foreach (string item in dicc.Valores)
                {
                    Console.WriteLine($"Valor obtenido con yield: {item}");
                }


                //Console.WriteLine($"Obteniendo elemento por clave no existente: {dicc.ObtenerValorPorClave(6)}");
                Console.WriteLine("Terminado ");
            }
        }
    }
}
