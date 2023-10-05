using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public abstract class Masa
    {
        public string descripcion { get; set; }
    }

    public class ALaPiedra : Masa
    {
        public ALaPiedra()
        {
            descripcion = "Masa a la piedra";
        }
    }

    public class Integral : Masa
    {
        public Integral()
        {
            descripcion = "Masa Integral";
        }
    }

    public class MasaMadre : Masa
    {
        public MasaMadre()
        {
            descripcion = "Masa Madre";
        }
    }
}
