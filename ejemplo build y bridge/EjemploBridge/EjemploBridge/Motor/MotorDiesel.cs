using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBridge.Motor
{
    public class MotorDiesel : IMotor
    {
        public void ConsumirCombustible()
        {
            RealizarExplosion();
        }

        public void RealizarExplosion()
        {
            Console.WriteLine("Realizo la explosion del diesel");
        }


        public void InyectarCombustible(double cantidad)
        {
            Console.WriteLine($"Inyectando {cantidad} ml de Diesel");
        }
    }
}
