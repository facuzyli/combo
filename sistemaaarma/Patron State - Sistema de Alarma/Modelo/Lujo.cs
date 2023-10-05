using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    class Lujo : Alarma
    {
        public string IPCamara { get; set; }
        public Lujo()
        {
            Timbre = 2;
            Frecuencia = 15;
            IPCamara = "192.168.1.15";
        }

        public override void Disparar()
        {
            Console.WriteLine("Disparando alarma Lujo: Timbre: {0}, Frecuencia:{1}, IPCámara: {2}", Timbre, Frecuencia, IPCamara);
        }
    }
}
