using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chain_of_Responsability
{
    public class Director : Handler
    {
        public override void Aprobar(Prestamo prestamo)
        {
            Console.WriteLine("Ejecutando Aprobacion - Soy el gerente");

            //Aplicar las reglas de Negocio....
            prestamo.Estado = EstadoAprobacion.Aprobado;
        }
    }
}
