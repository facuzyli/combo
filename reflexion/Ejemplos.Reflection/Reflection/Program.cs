using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Paso 1
            {             
                Service.MostrarPorNombre();

                //Paso 2
                Persona oPersona = new Persona();

                oPersona.Nombre = "Microsoft";
                oPersona.Apellido = "Reflection";                

                
                Service.InformarPropiedades(oPersona);

                //Paso 3
                Service.MostrarInformacionDeTiposDelEnsamblado("Test_Reflection.dll");

                //Paso 4
                //Service.CrearInstanciaInvocarMetodo("Test_Reflection.dll", "Test_Reflection.Persona", "Saludar");  
                Service.CrearInstanciaInvocarMetodo("Test_Reflection.dll", "Test_Reflection.Persona", "SaludarDos");

                Console.WriteLine("Presione una tecla para finalizar ...");
                Console.Read();
            }

        }
    }
}
