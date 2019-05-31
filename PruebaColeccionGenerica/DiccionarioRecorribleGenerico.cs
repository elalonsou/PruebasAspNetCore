using System;
using System.Collections.Generic;
using System.Text;

namespace PoCColeccionGenerica
{
    class DiccionarioRecorribleGenerico<TKey, TValue> 
    {
        private Dictionary<TKey, TValue> _diccionario;
        private List<TKey> _listaClaves;
        public DiccionarioRecorribleGenerico()
        {
            _diccionario = new Dictionary<TKey, TValue>();
            _listaClaves = new List<TKey>();
        }
           
        private int _contPos = 0;


        public void Añadir(TKey clave, TValue valor)
        {
            _diccionario.Add(clave, valor);
            _listaClaves.Add(clave);
        }

        public void MoverPrimero()
        {
            _contPos=0;
        }

        public int Cantidad()
        {
            return _diccionario.Count;
        }

        public bool EsUltimo()
        {
            if (_contPos + 1 >= _diccionario.Count || _diccionario.Count ==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoverSiguiente()
        {
            _contPos += 1;
        }

        public void MoverAnterior()
        {
            _contPos -= 1;
        }

        public TValue ObtenerActual()
        {
            return _diccionario[_listaClaves[_contPos]];
        }

        public TValue ObtenerValorPorClave(TKey clave)
        {
            return _diccionario[clave];
        }

        //Indexer
        public TValue this[TKey clave]
        {
            get
            {
                return _diccionario [clave];
            }
        }

        //------ Prueba uso de Yield ------
        // 
        public IEnumerable<TValue> Valores
        {
            get {
                foreach (TValue valor in _diccionario.Values)
                {
                    yield return valor;
                }
            }    
        }
    }
}
