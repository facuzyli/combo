using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class ConcreteStrategyLocal : IStrategyInmueble
    {
        public override decimal CalcularTotal(decimal p)
        {
            decimal total = p + CalcularComision(p) + CalcularImpuesto(p);

            return total - (total * 0.05m);
        }

        public override decimal CalcularComision(decimal p)
        {
            decimal comision10 = 0.1m;

            return (p * comision10);
        }

        public override decimal CalcularImpuesto(decimal p)
        {
            decimal impuesto5 = 0.12m;

            return (p * impuesto5);
        }
    }
}
