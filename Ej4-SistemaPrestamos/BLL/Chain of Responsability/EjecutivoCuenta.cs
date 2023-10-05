using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chain_of_Responsability
{
    public class EjecutivoCuenta : Handler
    {
        public override void Aprobar(Prestamo prestamo)
        {
            Console.WriteLine("Ejecutando Aprobacion - Ejecutivo de Cuenta");

            //Aplicar las reglas de Negocio....
            if (prestamo.Monto <= 100000)
                prestamo.Estado = EstadoAprobacion.Aprobado;
            else if (this.Siguiente != null)
                this.Siguiente.Aprobar(prestamo);
            else
                prestamo.Estado = EstadoAprobacion.Desaprobado;
        }
    }
}
