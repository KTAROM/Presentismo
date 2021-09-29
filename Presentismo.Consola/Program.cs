using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentismo.Biblioteca.Entidades;
using Presentismo.Excepciones;

namespace Presentismo.Consola
{
    class Program
    {
        private static Presentismo1 _presentismo;
        static Program()
        {
            _presentismo = new Presentismo1();
        }
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            bool activo = true;
            do
            {
                Console.Clear();
                DesplegarOpcionesMenu();
                string opcionMenu = Console.ReadLine(); // pedir el valor
                switch (opcionMenu.ToUpper())
                {
                    case "1":
                        TomarAsistencia(preceptorActivo);
                        break;
                    case "2":
                        MostrarAsistencia();
                        break;
                    case "X":
                        activo = false;
                        // SALIR
                        break;
                    default:
                        Console.WriteLine("La opción ingresada es incorrecta. Vuelva a intentarlo");
                        Console.Clear();
                        break;
                }
            } while (activo);
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor p)
        {
            Console.Clear();
            bool asistencia = false;
            Console.WriteLine("Ingrese la fecha de control de asistencia");
            string fecha = Console.ReadLine();
            
            DateTime fechaReal = DateTime.Today;
            List<Alumno> ListaAlumnos = new List<Alumno>();
            // Ingreso fecha
            try
            {
               ListaAlumnos = _presentismo.GetListaAlumnos(fecha);
            }
            catch
            {
                AsistenciaExistenteEseDiaException ex;
                Console.ReadKey();
            }
            // Listar los alumnos
            
            string respuesta = "";
            foreach (Alumno alum in ListaAlumnos)
            {
                do
                {
                    Console.WriteLine("Alumno " + alum.Nombre + " " + alum.Apellido + "\n"
                        + "Presente: S" + "\n" + "Ausente: N");
                    respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S" && respuesta != "N")
                    {
                        Console.WriteLine("Usted ingreso una respuesta incorrecta, vuelva a intentar");
                    }
                    else
                    {
                        if (respuesta == "S")
                        {
                            asistencia = true;
                        }
                        else { asistencia = false; }
                    }

                } while (respuesta != "S" && respuesta != "N");

               Asistencia asist = new Asistencia(fecha, fechaReal, p, alum, asistencia);
                // List<Asistencia> Listaasist = _presentismo.GetAsistenciasPorFecha(fecha);
                //_presentismo.AgregarAsistencia(Listaasist,fecha);
                
                _presentismo.AgregarAsistencia(asist, fecha);
               
            }
           
            /*  foreach(Asistencia asist in _presentismo.GetAsistenciasPorFecha(fecha))
              {
                  Console.WriteLine(asist.ToString());
              }*/
            // para cada alumno solo preguntar si está presente

            // agrego la lista de asistencia

            // Error: mostrar el error y que luego muestre el menu nuevamente
        }
        static void MostrarAsistencia()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la fecha de control de asistencia");
            string fecha = Console.ReadLine();

           List<Asistencia> ListaAsist= _presentismo.GetAsistenciasPorFecha(fecha);

            foreach (Asistencia asist in ListaAsist)
            {
               Console.WriteLine(asist.ToString());
            
            }
            Console.ReadLine();
            // ingreso fecha

            // muestro el toString de cada asistencia
        }
    }

}

