using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    public class Cliente
    {
        public String Nombre { get; set; }
        public Alarma Estado { get; set; }

        public void Disparar()
        {
            Estado.Disparar();
        }
    }
}
