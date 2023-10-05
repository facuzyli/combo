using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder builder = new PizzaJamonBuilder();
            Pizza pizzaJamon = builder.BuildPizza();
            Console.WriteLine(pizzaJamon.ToString());

            builder = new PizzaLightBuilder();
            Pizza pizzaLight = builder.BuildPizza();
            Console.WriteLine(pizzaLight.ToString());
        }
    }
}
