using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public abstract class Extra
    {
        public string descripcion { get; set; }
    }

    public class Jamon : Extra
    {
        public Jamon()
        {
            descripcion = "Jamon";
        }
    }

    public class Anana : Extra
    {
        public Anana()
        {
            descripcion = "Anana";
        }
    }
}
