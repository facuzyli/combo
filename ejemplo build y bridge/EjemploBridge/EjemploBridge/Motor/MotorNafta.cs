using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBridge.Motor
{
    public class MotorNafta : IMotor
    {
        public void ConsumirCombustible()
        {
            RealizarCombustion();
        }

        public void RealizarCombustion()
        {
            Console.WriteLine("Realizamos la combustion de la Nafta");
        }

        public void InyectarCombustible(double cantidad)
        {
            Console.WriteLine($"Inyectando {cantidad} ml de Nafta");

        }
    }
}
