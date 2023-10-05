using EjemploBridge.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBridge.Vehiculo
{
    public abstract class Auto
    {
        private IMotor motor;

        public Auto(IMotor Motor)
        {
            this.motor = Motor;
        }

        public void Acelerar(double combustible)
        {
            motor.InyectarCombustible(combustible);
            motor.ConsumirCombustible();
        }

        public void Frenar()
        {
            Console.WriteLine("El vehiculo se encuentra frenado");
        }

        //Metodo abstracto
        public abstract void MostrarCaracteristicas();
    }
}
