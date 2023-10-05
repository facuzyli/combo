using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Patron_State___Sistema_de_Alarma
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Cliente client = new Cliente();

                    var appSettings = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location).AppSettings;
                    string estado = appSettings.Settings["Estado"].Value;

                    Type tipo = Type.GetType(client.GetType().Namespace + "." + estado);

                    if (tipo == null) //Este estado no existe en la configuración actual...
                                      //Levanto la dll               
                        client.Estado = (Alarma)(Activator.CreateInstanceFrom("NuevoEstado.dll", typeof(Alarma).Namespace + "." + estado)).Unwrap();
                    else
                        client.Estado = (Alarma)Activator.CreateInstance(tipo);

                    client.Disparar();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                System.Threading.Thread.Sleep(5000);
            }

        }
    }
}
