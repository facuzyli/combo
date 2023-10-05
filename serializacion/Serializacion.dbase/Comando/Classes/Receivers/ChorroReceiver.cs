using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    public abstract class ChorroReceiver
    {
        protected bool encendido = false;
        protected TipoChorro TipoChorro;

        public void Desconectar()
        {
            encendido = false;
        }

        public abstract TipoChorro Conectar();
    }

    public enum TipoChorro { Directo, Ataque, Proteccion };
}
