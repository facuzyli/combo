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
        protected TipoChorro TipoChorro; //Solo para fines de aprendizaje, con reflection no necesitaríamos este atributo...

        public void Desconectar()
        {
            encendido = false;
        }

        public abstract TipoChorro Conectar(); //Lo mismo la devolución de TipoChorro, solo para poder mostrar la solución
    }

    public enum TipoChorro { Directo, Ataque, Proteccion };

}
