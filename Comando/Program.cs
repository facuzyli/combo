using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comando
{
    class Program
    {
        static void Main(string[] args)
        {

            ChorroReceiver chorroDirecto = new ChorroDirectoReceiver();
            ChorroReceiver chorroAtaque= new ChorroAtaqueReceiver();
            ChorroReceiver chorroProteccion = new ChorroProteccionReceiver();

            //Creamos los objetos Command que encapsulan los métodos de las clases anteriores
            ICommand conectar = new ConectarCommand(chorroDirecto);
            ICommand desconectar = new DesconectarCommand(chorroDirecto);

            // Creamos un nuevo Invoker (el objeto que será desacoplado de los chorros)
            IInvoker invoker = new ControladorChorroInvoker();

            // Le asociamos los objetos Command y los ejecutamos
            // El objeto invoker invoca el método 'Execute()' sin saber en ningún momento
            // qué es lo que se está ejecutando realmente.
            invoker.SetCommand(conectar);      //Asociamos el ICommand
            invoker.Invoke();                  //Hacemos que se ejecute ICommand.Execute()

            // Realizamos lo mismo con el resto de instancias que implementan ICommand.
            // Como podemos ver, el ICommand puede asignarse en tiempo de ejecucion
            invoker.SetCommand(desconectar);
            invoker.Invoke();

            conectar = new ConectarCommand(chorroAtaque);
            desconectar = new DesconectarCommand(chorroAtaque);

            invoker.SetCommand(conectar);      // Asociamos el ICommand-
            invoker.Invoke();                         // Hacemos que se ejecute ICommand.Execute()
            invoker.SetCommand(desconectar);
            invoker.Invoke();

            conectar = new ConectarCommand(chorroProteccion);
            desconectar = new DesconectarCommand(chorroProteccion);

            invoker.SetCommand(conectar);      // Asociamos el ICommand
            invoker.Invoke();                         // Hacemos que se ejecute ICommand.Execute()
            invoker.SetCommand(desconectar);
            invoker.Invoke();

            Console.ReadLine();
        }
    }
}
