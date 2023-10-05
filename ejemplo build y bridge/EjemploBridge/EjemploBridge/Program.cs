using EjemploBridge.Motor;
using EjemploBridge.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IMotor motorDiesel = new MotorDiesel();
            IMotor motorNafta = new MotorNafta();

            Auto auto = new Monovolumen(motorNafta,true);

            auto.MostrarCaracteristicas();
            auto.Acelerar(2.5d);
            auto.Frenar();

            auto = new Monovolumen(motorDiesel, false);

            auto.MostrarCaracteristicas();
            auto.Acelerar(2.5d);
            auto.Frenar();

            Console.ReadKey();

        }
    }
}
