using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;

        public Persona(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }
        public Persona()
        { }
        public string Nombre
        {
           get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public override string ToString()
        {
           return("Nombre: " + this._nombre);
        }
        internal virtual string Display()
        {
            return ToString();
        }
    }
}
