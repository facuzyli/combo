using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploBuilder
{
    public class Pizza
    {
        Masa masa;
        Salsa salsa;
        Extra extra;
        string tipo;

        public Pizza(Masa masa, Salsa salsa, Extra extra, string tipo)
        {
            this.masa = masa;
            this.salsa = salsa;
            this.extra = extra;
            this.tipo = tipo;
        }

        public override string ToString()
        {
            return $"Tipo : {tipo} - Masa {masa.descripcion} - Salsa {salsa.Descripcion} - Extra {extra.descripcion}";
        }
    }
}
