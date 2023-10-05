using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Repository
    {
        private BinaryFormatter _formateadorBinario = new BinaryFormatter();

        private static Repository _instancia;
        
        private static string _path = ConfigurationManager.AppSettings["BasePath"];

        private Repository()
        {
            
        }

        // '' <summary>
        // '' Get Conexion
        // '' </summary>
        // '' <param name="pPath"></param>
        // '' <param name="pModo"></param>
        // '' <param name="pAcceso"></param>
        // '' <returns></returns>
        // '' <remarks></remarks>
        private Stream GetConexion(string pPath, FileMode pModo, FileAccess pAcceso)
        {
            return new FileStream(pPath, pModo, pAcceso);
        }

        // '' <summary>
        // '' 
        // '' </summary>
        // '' <param name="pInfoPropiedad"></param>
        // '' <param name="pPropiedad"></param>
        // '' <returns></returns>
        // '' <remarks></remarks>
        private static bool EsLaPropiedad(PropertyInfo pInfoPropiedad, string pPropiedad)
        {
            return pInfoPropiedad.Name == pPropiedad;
        }

        // '' <summary>
        // '' Singleton
        // '' </summary>
        // '' <returns></returns>
        // '' <remarks></remarks>
        public static Repository Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Repository();
            }

            return _instancia;
        }

        // '' <summary>
        // '' Grabar Objeto
        // '' </summary>
        // '' <param name="objeto"></param>
        // '' <remarks></remarks>
        public void Store(object objeto)
        {
            using (Stream flujo = this.GetConexion(Repository._path, FileMode.Append, FileAccess.Write))
            {
                this._formateadorBinario.Serialize(flujo, objeto);
                flujo.Close();
            }
        }

        // '' <summary>
        // '' System.Reflection:: Se brinda una propiedad y un valor y con dichos valores se busca en el archive Repositorio.bin
        // '' </summary>
        // '' <typeparam name="unTipo"></typeparam>
        // '' <param name="pPropiedad"></param>
        // '' <param name="pValor"></param>
        // '' <returns></returns>
        // '' <remarks>Hacemos uso de System.Reflection</remarks>
        public List<unTipo> LoadPorValor<unTipo>(string pPropiedad, object pValor)
        {
           
            List<unTipo> resultado = new List<unTipo>();
            object objetoTest;

            Stream flujo = this.GetConexion(Repository._path, FileMode.Open, FileAccess.Read);

            while (flujo.Position < flujo.Length)
            {
                objetoTest = this._formateadorBinario.Deserialize(flujo);

                //Compruebo que el nombre del objeto (CLASE) buscado coincida
                if (typeof(unTipo).FullName == objetoTest.GetType().FullName)
                {
                    if (this.Comparar<unTipo>((unTipo)objetoTest, pPropiedad, pValor))
                    {
                        resultado.Add((unTipo)objetoTest);
                    }
                }
            }


            flujo.Close();
            return resultado;
        }

        // '' <summary>
        // '' Select: Toma el primer objeto
        // '' </summary>
        // '' <typeparam name="unTipo"></typeparam>
        // '' <returns></returns>
        // '' <remarks></remarks>
        public unTipo LoadFirst<unTipo>()
        {
            //Objeto de retorno (Podría ser null)
            object objeto = null;
            object objetoTest; //Lo utilizo para comparar el objeto leido del stream contra el tipo de objeto deseado...
            
            //Obtengo el puntero al stream para la lectura
            Stream flujo = this.GetConexion(Repository._path, FileMode.Open, FileAccess.Read);

            //Voy leyendo objeto a objeto....
            while (flujo.Position < flujo.Length)
            {
                //Deserialize sabe cuánto tiene en bytes cada objeto...Para el desarrollador es transparente
                objetoTest = this._formateadorBinario.Deserialize(flujo);

                //Compruebo que el nombre del objeto (CLASE) buscado coincida (Requerimiento o Tarea, etc...)
                if (typeof(unTipo).FullName == objetoTest.GetType().FullName) //Reflection
                {
                    objeto = objetoTest; //Sí o sí copio la referencia para el return...
                    break; 
                }
            }
            flujo.Close();
            return (unTipo)objeto;
        }

        // '' <summary>
        // '' En este método utilice la técnica de Refection
        // '' </summary>
        // '' <typeparam name="unTipo"></typeparam>
        // '' <param name="objeto"></param>
        // '' <param name="pPropiedad"></param>
        // '' <param name="pValor"></param>
        // '' <returns></returns>
        // '' <remarks></remarks>
        private bool Comparar<unTipo>(unTipo objeto, string pPropiedad, object pValor)
        {
            bool resultado = false;
            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())
            {
                if (propiedad.Name == pPropiedad)
                {
                    if (propiedad.GetValue(objeto, null).ToString() == pValor.ToString())
                    {
                        resultado = true;
                        break;
                    }
                }
            }

            return resultado;
        }

        public void SerializarJson<unTipo>(object obj)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(unTipo));
            //Manejar stream en memoria...
            Stream msObj = new MemoryStream();
            js.WriteObject(msObj, obj);
            msObj.Position = 0; //Vuelvo a pos 0, para permitir la des...

            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();
            Console.WriteLine("Objeto con formateador json " + json);        
            
            //Aplico deserialización sobre el ojeto json en memoria
            msObj.Position = 0; //Vuelvo a pos 0, para permitir la des...
            object objetoOriginal = js.ReadObject(msObj);

            sr.Close();
            msObj.Close();
        }
    }
}
