using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BIZ;

namespace TestInmueble
{
    //Versión con visitante:
    //https://www.csharptutorial.net/csharp-design-patterns/csharp-visitor-pattern/

    public class GestorVenta
    {
        public Inmueble Inmueble { get; set; }

        private IStrategyInmueble _inmuebleStrategy;

        public GestorVenta(Inmueble inm)
        {
            try
            {
                Inmueble = inm;

                if (Inmueble.GetType().Name == "Casa")
                    this._inmuebleStrategy = new ConcreteStrategyCasa();

                if (Inmueble.GetType().Name == "Campo")
                    this._inmuebleStrategy = new ConcreteStrategyCampo();

                if (Inmueble.GetType().Name == "Departamento")
                    this._inmuebleStrategy = new ConcreteStrategyDepartamento();

                if (Inmueble.GetType().Name == "Local")
                    this._inmuebleStrategy = new ConcreteStrategyLocal();














                //var appSettings = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location).AppSettings;
                //string estrategia = appSettings.Settings["Strategy"].Value;

                Type tipo = Type.GetType("BLL.ConcreteStrategy" + inm.GetType().Name);

                if (tipo != null)
                    this._inmuebleStrategy = (IStrategyInmueble)Activator.CreateInstance(tipo);
                else
                    Console.WriteLine("No se encontró ninguna estrategia solicitada");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public decimal CalcularComision()
        {
            if (_inmuebleStrategy == null)
                throw new Exception("No se ha seteado una estrategia");

            return _inmuebleStrategy.CalcularComision(Inmueble.Precio);
        }

        public decimal CalcularImpuesto()
        {
            return _inmuebleStrategy.CalcularImpuesto(Inmueble.Precio);
        }

        public decimal CalcularTotal()
        {
            return _inmuebleStrategy.CalcularTotal(Inmueble.Precio);
        }
    }
}
