using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    class Plus : Alarma
    {
        public string Telefono { get; set; }

        public Plus()
        {
            Timbre = 3;
            Frecuencia = 20;
            Telefono = "165165165";
        }

        public override void Disparar()
        {
            Console.WriteLine("Disparando alarma Plus: Timbre: {0}, Frecuencia:{1}, Teléfono: {2}", Timbre, Frecuencia, Telefono);
        }
    }
}
