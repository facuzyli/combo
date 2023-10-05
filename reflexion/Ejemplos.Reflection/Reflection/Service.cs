using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public static class Service
    {        
        public static void InformarPropiedades(object pObjeto)
        {
            
            Type tipo = pObjeto.GetType();

            PropertyInfo[] propiedades = tipo.GetProperties();

            //Console.WriteLine(pObjeto.Nombre);

            foreach (PropertyInfo propiedad in propiedades)
            {
                //string cualquier = "Otra cosa";
                //object ret = propiedad.GetValue(cualquier, null);

                object retorno = propiedad.GetValue(pObjeto, null);                

                Console.WriteLine("Propiedad: {0}, valor: {1}", propiedad.Name, retorno);
            }

            //string str = "gaston";

            //foreach (PropertyInfo propiedad in propiedades)
            //{
            //    Console.WriteLine("Propiedad: {0}, valor: {1}", propiedad.Name, propiedad.GetValue(str, null));
            //}       
        }


        public static void CrearInstanciaInvocarMetodo(string pAssembly, string pClase, string pMetodo)
        {
            Assembly ensamblado = Assembly.LoadFrom(pAssembly);
            Type tipo = ensamblado.GetType(pClase);
            object instancia = Activator.CreateInstance(tipo, true);

            //Invocar método sin parámetros
            //MethodInfo metodo = tipo.GetMethod(pMetodo, new Type []{ });
            //metodo.Invoke(instancia, null);

            //Si quiero llamar al Saludar con parámetros
            //string str = String.Empty;
            //MethodInfo metodo = tipo.GetMethod(pMetodo, new Type[] { str.GetType() });
            //object ret = metodo.Invoke(instancia, new String[] { "hola reflection" });

            //Para llamar a un método privado...
            MethodInfo metodo = tipo.GetMethod(pMetodo, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            metodo.Invoke(instancia, null);
        }

        /// <summary>
        /// Muestra los datos de un tipo. Para obtener el tipo a analizar se utiliza el nombre del mismo
        /// </summary>
        /// <remarks></remarks>
        public static void MostrarPorNombre()
        {
            Type t = Type.GetType("System.String");

            Console.WriteLine("Nombre: {0}", t.Name);

            Console.WriteLine("Tipo utilizado por el CLR: {0}", t.FullName);

            Console.WriteLine("Es una clase: {0}", t.IsClass);

            Console.WriteLine("Es público?: {0}", t.IsPublic);
        }


        public static void MostrarInformacionDeTiposDelEnsamblado(string pAssembly)
        {
            // ---------------------------------------------------------
            // Se obtiene el assembly
            Assembly ensamblado = Assembly.LoadFrom(pAssembly);
            Type[] tipos = ensamblado.GetTypes();

            foreach (Type tipo in tipos)
            {
                if (tipo.Name == "Persona")
                {
                    Console.WriteLine("Tipo de la clase: {0}", tipo.Name);
                    Console.WriteLine();
                    Console.WriteLine("Namespace: {0}", tipo.Namespace);

                    Console.WriteLine();

                    MostrarPropiedades(tipo);
                    MostrarMetodos(tipo);
                }
            }
        }


        public static void MostrarConstructores()
        {
        }


        public static void MostrarPropiedades(Type tipo)
        {
            PropertyInfo[] propiedades = null;

            propiedades = tipo.GetProperties();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Propiedades:");


            foreach (PropertyInfo propiedad in propiedades)
            {
                Console.WriteLine("Propiedad: {0}:   Tipo: {1}", propiedad.Name, propiedad.PropertyType.ToString());
                Console.WriteLine();

            }

            Console.WriteLine("-----------------------------------------");

        }


        public static void MostrarMetodos(Type tipo)
        {
            MethodInfo[] metodos = null;
            ParameterInfo[] parametros = null;

            metodos = tipo.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            //metodos = tipo.GetMethods();             
            
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Metodos:");

            foreach (MethodInfo metodo in metodos)
            {
                Console.WriteLine("Nombre del metodo: {0} Privado?:{1}", metodo.Name, metodo.IsPrivate);

                parametros = metodo.GetParameters();

                Console.WriteLine("Parametros:");
                foreach (ParameterInfo parametro in parametros)
                {                    
                    Console.WriteLine("Nombre: {0} Tipo {1}", parametro.Name, parametro.ParameterType.ToString());
                }
            }

            Console.WriteLine("-----------------------------------------");
        }
    }
}
