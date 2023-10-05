using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public class PizzaJamonBuilder : PizzaBuilder
    {

        public override Extra BuildExtra()
        {
            return new Jamon();
        }

        public override Masa BuildMasa()
        {
            return new ALaPiedra();
        }

        public override Salsa BuildSalsa()
        {
            return new Tomate();
        }
    }
}
