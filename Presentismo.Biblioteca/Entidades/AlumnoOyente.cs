using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public class AlumnoOyente : Alumno

    {   // Constructor
        public AlumnoOyente(int registro, string nombre, string apellido): base(registro, nombre,apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
           
        }
        internal override string Display()
        {
            return ("El alumno: " + this._nombre + "es OYENTE");
        }

    }
}
