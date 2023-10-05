using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    class ChorroDirecto : ChorroReceiver
    {
        public override TipoChorro Conectar()
        {
            this.encendido = true;
            this.TipoChorro = TipoChorro.Directo;
            return this.TipoChorro;
        }
    }
}
