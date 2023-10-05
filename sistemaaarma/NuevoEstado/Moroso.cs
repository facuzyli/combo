using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    public class Moroso : Alarma
    {
        public override void Disparar()
        {
            Console.WriteLine("Usted debe mucho dinero $$$");
        }
    }
}
