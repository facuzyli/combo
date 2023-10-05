using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    class ChorroAtaqueReceiver : ChorroReceiver
    {
        public override TipoChorro Conectar()
        {
            //Acá iría la implementación futura del chorro de ataque...
            this.encendido = true;
            this.TipoChorro = TipoChorro.Ataque;
            return this.TipoChorro; 
        }
    }
}
