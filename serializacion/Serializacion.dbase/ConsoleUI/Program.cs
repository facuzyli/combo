using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tarea primerTareaRecuperada = Repository.Instancia().LoadFirst<Tarea>();
            //Console.WriteLine(primerTareaRecuperada.Nombre);

            //Requerimiento primerRequerimientoRecuperado = Repository.Instancia().LoadFirst<Requerimiento>();
            //Console.WriteLine(primerRequerimientoRecuperado.Descripcion);


            Tarea tarea1 = new Tarea("Aprendiendo Serialization", "Desc", DateTime.Now);
            Repository.Instancia().Store(tarea1);

            Tarea tarea2 = new Tarea("Aprendiendo Serialization 2", "Desc 2", DateTime.Now.AddHours(1));
            Repository.Instancia().Store(tarea2);




            Requerimiento unRequerimiento = new Requerimiento(1001, "Diseño detallado");
            Repository.Instancia().Store(unRequerimiento);
            Repository.Instancia().Store("Un dato más");

            /*
            Repository.Instancia().SerializarJson<Requerimiento>(unRequerimiento);
            Repository.Instancia().Store(unRequerimiento);
            */
            unRequerimiento = new Requerimiento(5670, "Mantenimiento correctivo");
            unRequerimiento.AddTarea(new Tarea("Diagrama de clases", "Descripcion de la primer tarea", DateTime.Parse("17/10/2012")));
            unRequerimiento.AddTarea(new Tarea("Segunda tarea", "Descripcion de la segunda tarea", DateTime.Parse("17/10/2012")));
            Repository.Instancia().Store(unRequerimiento);

            //Requerimiento unRequerimiento2 = new Requerimiento(1001, "Diseño detallado");
            Repository.Instancia().SerializarJson<Requerimiento>(unRequerimiento);
            Repository.Instancia().Store(unRequerimiento);

            List<Requerimiento> requerimientos = new List<Requerimiento>();

            //Tarea tareaGuardada = new Tarea("Test", "Tarea de prueba", DateTime.Now);
            //Repository.Instancia().Store(tareaGuardada);

            unRequerimiento = Repository.Instancia().LoadFirst<Requerimiento>();

            Console.WriteLine("Descripcion: {0}", unRequerimiento.Descripcion);
            Console.WriteLine(((unRequerimiento.GetTareas().Count() > 0) ? "--Listado de tareas--" : String.Empty));

            foreach (Tarea tarea in unRequerimiento.GetTareas())
            {
                Console.WriteLine("Tarea {0}: {1} [Fecha: {2}]", tarea.Nombre, tarea.Descripcion, tarea.FechaFin.ToShortDateString());
            }

            // 'System.Reflection
            requerimientos = Repository.Instancia().LoadPorValor<Requerimiento>("Numero", 5670);

            foreach (Requerimiento req in requerimientos)
            {
                Console.WriteLine("Descripcion: {0}", req.Descripcion);
                foreach (Tarea tarea in req.GetTareas())
                {
                    Console.WriteLine("Requerimiento: {0}, Tarea: {1}", req.Descripcion, tarea.Nombre);
                }
            }
            Console.Read();
        }
    }
}
