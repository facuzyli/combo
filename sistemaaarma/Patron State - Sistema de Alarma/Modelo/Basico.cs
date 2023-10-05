using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    class Basico : Alarma
    {
        public Basico()
        {
            Timbre = 1;
            Frecuencia = 10;
        }

        public override void Disparar()
        {
            //El patrón state nos permite en base a una condición modificar el estado del objeto contenedor...
            //ClienteContext.Estado = new Plus();

            //if (ClienteContext.FacturasAdeudadas > 0)
            //{
            //    ClienteContext.Estado = new Moroso();
            //}

            Console.WriteLine("Disparando alarma básica: Timbre: {0}, Frecuencia:{1}",Timbre, Frecuencia); 
        }
    }
}
