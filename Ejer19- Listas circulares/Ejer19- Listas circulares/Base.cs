using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer19__Listas_circulares
{
    class Base
    {


        private string _nombre;
        public string nombre { get { return _nombre; } }

        private int _minutos;  //minutos para llegar desde la base anterior
        public int minutos { get { return _minutos; } }

        private Base _baseAnterior;
        public Base baseAnterior {
            get { return _baseAnterior; }
            set { _baseAnterior = value; }
        }

        private Base _baseSiguiente;
        public Base baseSiguiente {
            get { return _baseSiguiente; }
            set { _baseSiguiente = value; }
        }

        public Base(string nombre, int minutos) {
            _nombre = nombre;
            _minutos = minutos;
            _baseAnterior = null;
            _baseSiguiente = null;
        }

        public override string ToString()
        {
            return "Base" + Environment.NewLine + "Nombre de la base: " + nombre + Environment.NewLine + "Tarda: " + minutos + " minutos."+Environment.NewLine;
        }
    }
}
