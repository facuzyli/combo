using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public abstract class PizzaBuilder
    {
        public abstract Masa BuildMasa();
        public abstract Salsa BuildSalsa();

        public abstract Extra BuildExtra();

        public string descripcion;


        public Pizza BuildPizza()
        {
            Masa masa = BuildMasa();
            Salsa salsa = BuildSalsa();
            Extra extra = BuildExtra();

            return new Pizza(masa, salsa, extra, descripcion);
        }

    }
}
