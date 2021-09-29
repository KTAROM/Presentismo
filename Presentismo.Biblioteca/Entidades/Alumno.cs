using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public abstract class Alumno:Persona
    {
        private int _registro;
       
        // constructor
        public Alumno(int registro, string nombre, string apellido): base(nombre, apellido)
        {
            this._registro = registro;
   
        }
                
        internal override string Display()
        {
            return ("Alumno: " + this._nombre + "( " + this._registro + " )");
        }
    }
}
