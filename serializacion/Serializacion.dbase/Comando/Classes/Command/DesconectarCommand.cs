using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    public class DesconectarCommand : ICommand
    {
        // Referencia al objeto cuyo método se quiere encapsular
        private ChorroReceiver chorro;

        // El constructor inyectará el objeto cuyo método se quiere encapsular
        public DesconectarCommand(ChorroReceiver chorro)
        {
            this.chorro = chorro;
        }

        // El método Execute() ejecutará el método encapsulado
        public void Execute()
        {
            chorro.Desconectar();
            Console.WriteLine("Apagando el chorro...");
        }
    }

}
