using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentismo.Biblioteca.Entidades
{
    public class Asistencia
    {
        private string _fechaReferencia;
        private DateTime _fechaHoraReal;
        private Preceptor _Preceptor;
        private Alumno _Alumno;
        private bool _estaPresente;


        public string FechaReferencia
        {
            get { return _fechaReferencia; }
            set { _fechaReferencia = value; }
        }
        public override string ToString()       
        {
            string presente;
            if(_estaPresente==true)
            { presente = "SI"; }
            else { presente = "NO"; }
            
            return ("Fecha de referencia: "+this._fechaReferencia+"\n"+_Alumno.Display()+"\nEsta presente: "+presente+
                "\nPor "+_Preceptor.Display()+"\nRegistrado el "+_fechaHoraReal.ToString());
        }
        public Asistencia(string fechaReferencia, DateTime fechaReal, Preceptor Preceptor,
            Alumno alumno, bool presente)
        {
            this._fechaReferencia = fechaReferencia;
            this._fechaHoraReal = fechaReal;
            this._Preceptor = Preceptor;
            this._Alumno = alumno;
            this._estaPresente = presente;
        }
        public Asistencia()
        { }
    }
}

