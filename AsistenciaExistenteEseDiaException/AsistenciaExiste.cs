using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Excepciones
{
        public class AsistenciaExistenteEseDiaException : Exception
    {
        public AsistenciaExistenteEseDiaException(string fecha) : base()
        {
            Console.WriteLine("La fecha " + fecha + " que ingreso ya existe");
        }
    }
}
