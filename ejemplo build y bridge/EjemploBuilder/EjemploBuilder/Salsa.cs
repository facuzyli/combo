using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public abstract class Salsa
    {
        public string Descripcion { get; set; }
    }

    public class Tomate : Salsa
    {
        public Tomate()
        {
            Descripcion = "Salsa de Tomate";
        }
    }

    public class Light : Salsa
    {
        public Light()
        {
            Descripcion = "Salsa Light, mas cara pero mas sana";
        }
    }
}
