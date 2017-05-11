using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer19__Listas_circulares
{
    class Ruta
    {
        public Base primerBase;
        public Base ultimaBase;
        private int _numBases;
        public int numBases { get { return _numBases; } }

        public Ruta() {
            primerBase = null;
            ultimaBase = null;
            _numBases = 0;
        }

        public void agregar(Base baseNueva) {
            if (primerBase == null)
                primerBase = baseNueva;
            else
                agregar(primerBase, baseNueva);

            ultimaBase = baseNueva;
            primerBase.baseAnterior = ultimaBase;
            ultimaBase.baseSiguiente = primerBase;
            _numBases++;
        }

        private void agregar(Base ultima, Base nueva) {
            if (ultima.baseSiguiente == primerBase){
                ultima.baseSiguiente = nueva;
                nueva.baseAnterior = ultima;
            }
            else 
                agregar(ultima.baseSiguiente, nueva);
        }

        public Base buscar(string nombre) {
            Base actual = primerBase;
            bool baseEncontrada = false;

            if (actual != null) {
                while (actual.baseSiguiente != primerBase && baseEncontrada == false){
                    if (actual.nombre == nombre)
                        baseEncontrada = true;
                    else
                        actual = actual.baseSiguiente;
                }

                if (actual == ultimaBase)
                    if (actual.nombre == nombre)
                        baseEncontrada = true;

                if (baseEncontrada)
                    return actual;
                else
                    return null;
            }
            return null;

            
        }

        public bool eliminar(string nombre) {
            bool baseEliminada = false;
            
            Base baseAEliminar=buscar(nombre);
            if (baseAEliminar != null) {
                if (_numBases != 1){
                    baseAEliminar.baseAnterior.baseSiguiente = baseAEliminar.baseSiguiente;
                    baseAEliminar.baseSiguiente.baseAnterior = baseAEliminar.baseAnterior;

                    if (baseAEliminar == primerBase)
                        primerBase = baseAEliminar.baseSiguiente;
                    else
                        if (baseAEliminar == ultimaBase)
                        ultimaBase = baseAEliminar.baseAnterior;
                }
                else {
                    primerBase = null;
                    ultimaBase = null;
                }
                

                baseEliminada = true;
                _numBases--;
            }
            return baseEliminada;
        }

        public bool eliminarInicio() {
            bool baseEliminada = false;
            if (primerBase != null) {
                if (_numBases != 1){
                    ultimaBase.baseSiguiente = primerBase.baseSiguiente;
                    primerBase.baseSiguiente.baseAnterior = ultimaBase;
                    primerBase = primerBase.baseSiguiente;
                }
                else {
                    primerBase = null;
                    ultimaBase = null;
                }
                
                baseEliminada = true;
                _numBases--;
            }
            return baseEliminada;
        }

        public bool eliminarFin() {
            bool baseElimada = false;
            if (ultimaBase != null) {
                if (_numBases != 1){
                    ultimaBase.baseAnterior.baseSiguiente = primerBase;
                    primerBase.baseAnterior = ultimaBase.baseAnterior;
                    ultimaBase = ultimaBase.baseAnterior;
                }
                else {
                    primerBase = null;
                    ultimaBase = null;
                }
                
                baseElimada = true;
                _numBases--;
            }
            return baseElimada;
        }

        public void agregarInicio(Base baseNueva) {
            if (primerBase == null)
                agregar(baseNueva);
            else {
                ultimaBase.baseSiguiente = baseNueva;
                baseNueva.baseSiguiente = primerBase;
                primerBase.baseAnterior = baseNueva;
                primerBase = baseNueva;
                primerBase.baseAnterior = ultimaBase;
            }
            _numBases++;
        }

        public string reporte()
        {
            string texto = "";
            if (primerBase!=null)
                return texto = crearReporte(primerBase);
            else
                return texto;
        }

        public string crearReporte(Base actual)
        {
            string texto = "";
            if (actual.baseSiguiente == primerBase)
                return texto  + actual.ToString();
            else
                return texto = actual.ToString() + Environment.NewLine + crearReporte(actual.baseSiguiente);
        }


        public string recorrido(string nombre, DateTime horaInicio, DateTime horaFin) {
            string recorrido = "";

            DateTime horaActual = horaInicio;
            Base inicial = buscar(nombre);
            Base actual = inicial;
            int contador = 0;

            if (actual != null) {
                while (actual.baseSiguiente != inicial){
                    recorrido += "\t" + actual.nombre;
                    actual = actual.baseSiguiente;
                }
                recorrido += "\t" + actual.nombre + Environment.NewLine;
                actual = actual.baseSiguiente;

                int contadorBases = 0;
                while (horaActual.AddMinutes(Convert.ToDouble(actual.minutos)) <= horaFin){
                    double minutos= Convert.ToDouble(actual.minutos);
                    if (contador == 0){
                        recorrido += "   " + horaInicio.ToShortTimeString();
                        contador++;
                    }
                    else {
                        horaActual = horaActual.AddMinutes(minutos);
                        recorrido += "   " + horaActual.ToShortTimeString();
                    }

                    contadorBases++;
                    if (contadorBases >= numBases){
                        recorrido += Environment.NewLine;
                        contadorBases = 0;
                    }
                    actual = actual.baseSiguiente;
                }
                    actual = null;
            }
            return recorrido;

        }

        public bool insertarDespuesDe(string nombre, Base baseNueva) {
            Base baseAInsertarDespues = buscar(nombre);
            bool baseInsertada = false;

            if (baseAInsertarDespues != null) {
                baseNueva.baseAnterior = baseAInsertarDespues;
                baseNueva.baseSiguiente = baseAInsertarDespues.baseSiguiente;
                baseAInsertarDespues.baseSiguiente.baseAnterior = baseNueva;
                baseAInsertarDespues.baseSiguiente = baseNueva;

                if (baseAInsertarDespues == ultimaBase)
                    ultimaBase = baseNueva;

                baseInsertada = true;
                _numBases++;
            }

            return baseInsertada;
        }
    }
}
