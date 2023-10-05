using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal abstract class IStrategyInmueble
    {
        public abstract decimal CalcularTotal(decimal p);
        public abstract decimal CalcularComision(decimal p);
        public abstract decimal CalcularImpuesto(decimal p);
    }
}
