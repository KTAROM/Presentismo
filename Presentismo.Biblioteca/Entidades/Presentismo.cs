using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentismo.Excepciones;

namespace Presentismo.Biblioteca.Entidades
{
    public class Presentismo1
    {
        List<Preceptor> _preceptores;
        List<Alumno> _alumnos;
        List<Asistencia> _asistencias;
        List<string> _fechas;

        // Constructor

        public Presentismo1()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();
            _fechas = new List<string>();
            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juarez", "cjua@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "cjai@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos"));
        }

        public List<Asistencia> Asistencias
        {
            get { return this._asistencias; }
        }

        private bool AsistenciasRegistradas(string fecha)
        {
            bool AsistRegistrada = false;
            foreach (Asistencia asist in _asistencias)
            {
                if (asist.FechaReferencia == fecha)
                { AsistRegistrada = true;                 
                }
            }           
             return AsistRegistrada;
        }

        private int GetCantidadAlumnosRegulares()
        {
            int cantidad = 0;
            if (_alumnos == null)
            {
                throw new SinAlumnos();
            }
            else
            {
                foreach (Alumno alum in _alumnos)
                {
                    if (alum is AlumnoRegular)
                    { cantidad += 1; }
                }
            }

            return cantidad;
        }

        public Preceptor GetPreceptorActivo()
        {
            Preceptor Preceptor1 = new Preceptor();
           foreach(Preceptor p in _preceptores)
            {
                Preceptor1 = p;
            }
            return Preceptor1;
        }

        public List<Alumno> GetListaAlumnos(string fecha)
        {
            if(AsistenciasRegistradas(fecha))
            {
                throw new AsistenciaExistenteEseDiaException(fecha);
            }
            List<Alumno> alumnos1 = new List<Alumno>();
            foreach(Alumno alum in _alumnos)
            {
                if(alum is AlumnoRegular)
                {
                    alumnos1.Add((AlumnoRegular)alum);
                }
            }
            return alumnos1;

        }

        public void AgregarAsistencia(List<Asistencia> asistencias, string fecha)
        {
            if(_asistencias.Count()!=GetCantidadAlumnosRegulares())
            {
                throw new AsistenciaInconsistente();
            }
           // asistencias.Add - VER COMO RESOLVER!!! Falta que tenga el objeto a agregar

        }
        public List<Asistencia> AgregarAsistencia(Asistencia asistencia, string fecha)
        {
            _asistencias.Add(asistencia);
            AgregarAsistencia(_asistencias, fecha);
            return _asistencias;
        }
       
        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            List<Asistencia> asistencias1 = _asistencias;
     
            List<Asistencia> ListaAsist = (asistencias1.FindAll(x => x.FechaReferencia == fecha));
            
            return ListaAsist;
        }
       

    }
}
