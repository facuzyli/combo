using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    public class ConectarCommand : ICommand
    {
        // Referencia al objeto cuyo método se quiere encapsular
        private ChorroReceiver chorro;

        // El constructor inyectará el objeto cuyo método se quiere encapsular
        public ConectarCommand(ChorroReceiver chorro)
        {
            this.chorro = chorro;
        }

        // El método Execute() ejecutará el método encapsulado
        public void Execute()
        {
            TipoChorro tipo = chorro.Conectar();
            Console.WriteLine(string.Format("Encendiendo chorro. Tipo de chorro: {0}", tipo));
        }
    }

}
