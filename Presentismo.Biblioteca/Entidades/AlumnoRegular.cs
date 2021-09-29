using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public class AlumnoRegular:Alumno
    {
        private string _email;

        // Constructor
        public AlumnoRegular(int registro, string nombre, string apellido, string email): base(registro, nombre, apellido)
        {
            this._email = email;
        }

        public string email
        {
            get { return this._email; }
        }
        
    }
}
