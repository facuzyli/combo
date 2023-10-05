using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BIZ;

namespace TestInmueble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Campo");
            Campo campo = new Campo();
            campo.Precio = 1500000;
            GestorVenta ventaCampo = new GestorVenta(campo);

            Console.WriteLine("Valor Propiedad: " + ventaCampo.Inmueble.Precio);
            Console.WriteLine("Total Boleto: " + ventaCampo.CalcularComision());
            Console.WriteLine("Total Impuesto: " + ventaCampo.CalcularImpuesto());
            Console.WriteLine("Total $ Propiedad: " + ventaCampo.CalcularTotal());


            Console.WriteLine("");
            Console.WriteLine("Casa");
            Casa casa = new Casa();
            casa.Precio = 10000;
            GestorVenta ventaCasa = new GestorVenta(casa);
            Console.WriteLine("Valor Propiedad: " + ventaCasa.Inmueble.Precio);
            Console.WriteLine("Total Boleto: " + ventaCasa.CalcularComision());
            Console.WriteLine("Total Impuesto: " + ventaCasa.CalcularImpuesto());
            Console.WriteLine("Total $ Propiedad: " + ventaCasa.CalcularTotal());

            Console.WriteLine("");
            Console.WriteLine("Departamento");
            Departamento depto = new Departamento();
            depto.Precio = 10000;
            GestorVenta ventaDepartamento = new GestorVenta(depto);
            Console.WriteLine("Valor Propiedad: " + ventaDepartamento.Inmueble.Precio);
            Console.WriteLine("Total Boleto: " + ventaDepartamento.CalcularComision());
            Console.WriteLine("Total Impuesto: " + ventaDepartamento.CalcularImpuesto());
            Console.WriteLine("Total $ Propiedad: " + ventaDepartamento.CalcularTotal());

            Console.WriteLine("");
            Console.WriteLine("Local");
            Departamento local = new Departamento();
            local.Precio = 600000;
            GestorVenta ventaLocal = new GestorVenta(local);
            Console.WriteLine("Valor Propiedad: " + ventaLocal.Inmueble.Precio);
            Console.WriteLine("Total Boleto: " + ventaLocal.CalcularComision());
            Console.WriteLine("Total Impuesto: " + ventaLocal.CalcularImpuesto());
            Console.WriteLine("Total $ Propiedad: " + ventaLocal.CalcularTotal());


            //MANEJO DE UN TIPO COMÚN EN UN LISTA TIPADA

            List<Inmueble> inmuebles = new List<Inmueble>();
            inmuebles.Add(campo);
            inmuebles.Add(casa);
            inmuebles.Add(depto);
            inmuebles.Add(local);

            Console.ReadLine();
            Console.Clear();

            foreach (Inmueble inm in inmuebles)
            {
                GestorVenta venta = new GestorVenta(inm);
                Console.WriteLine("Tipo Propiedad: {0}", inm.GetType().Name);
                Console.WriteLine("Valor Propiedad: " + venta.Inmueble.Precio);
                Console.WriteLine("Total Boleto: " + venta.CalcularComision());
                Console.WriteLine("Total Impuesto: " + venta.CalcularImpuesto());
                Console.WriteLine("Total $ Propiedad: " + venta.CalcularTotal());
                Console.WriteLine(System.Environment.NewLine);

                //Podía conocer cada tipo de inmueble con reflection...
                //if (venta.inmueble.GetType().Name == "Casa")
                //{
                //    Casa casita = (Casa)venta.inmueble;
                //    Console.WriteLine(casita.cantidadAmbiente);
                //}
            }



            Console.ReadLine();
        }
    }
}
