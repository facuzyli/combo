using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    public abstract class Alarma
    {
        //El patrón state nos permite gestionar el contexto (Cliente) que es el que contiene el State
        //public Cliente ClienteContext { get; set; }
        public int Timbre { get; set; }
        public int Frecuencia { get; set; }
        public abstract void Disparar();
    }
}
