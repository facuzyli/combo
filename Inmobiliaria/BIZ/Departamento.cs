using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class Departamento : Inmueble
    {
        public int CantidadAmbientes { get; set; }
        public int Antiguedad { get; set; }
        public int DepartamentosPisos { get; set; }
    }
}
