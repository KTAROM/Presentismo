using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public class Preceptor:Persona
    {
        private int _legajo;

        // Constructor

        public Preceptor(int legajo, string nombre, string apellido): base(nombre, apellido)
        {
            this._legajo = legajo;
           
        }
        public Preceptor()
        { }
        internal override string Display()
        {
            return ("Preceptor: " + this._apellido + "- Legajo: " + this._legajo);
        }
    }
}
