using BLL;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4_SistemaPrestamos
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente gaston = new Cliente();
            Prestamo prestamo = new Prestamo();
            prestamo.Cliente = gaston;
            prestamo.FechaSolicitud = DateTime.Now;
            prestamo.Monto = 900000;

            PrestamoService.Aprobar(prestamo);

            Console.WriteLine($"El prestamo quedo en estado { prestamo.Estado }");


        }
    }
}
