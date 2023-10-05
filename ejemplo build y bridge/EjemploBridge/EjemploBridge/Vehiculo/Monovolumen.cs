using EjemploBridge.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBridge.Vehiculo
{
    public class Monovolumen : Auto
    {
        public bool PuertaCorrediza;

        public Monovolumen(IMotor motor, bool puertaCorrediza) : base(motor)
        {
            this.PuertaCorrediza = puertaCorrediza;
        }

        public override void MostrarCaracteristicas()
        {
            Console.WriteLine("Es es un vehiculo monovolumen " 
                + (this.PuertaCorrediza ? "Con" : "Sin") + "puerta Corrediza");
        }
    }
}
