using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIZ;

namespace BLL
{
    internal class ConcreteStrategyCasa : IStrategyInmueble
    {
        public override decimal CalcularTotal(decimal p)
        {
            return p + CalcularComision(p) + CalcularImpuesto(p);
        }

        public override decimal CalcularComision(decimal p)
        {
            decimal comision10 = 0.1m;

            return (p * comision10);
        }

        public override decimal CalcularImpuesto(decimal p)
        {
            decimal impuesto5 = 0.05m;

            return (p * impuesto5);
        }
    }
}
