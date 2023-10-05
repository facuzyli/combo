﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chain_of_Responsability
{
    public class Gerente : Handler
    {
        public override void Aprobar(Prestamo prestamo)
        {
            Console.WriteLine("Ejecutando Aprobacion - Soy el gerente");

            //Aplicar las reglas de Negocio....
            if (prestamo.Monto <= 1000000)
                prestamo.Estado = EstadoAprobacion.Aprobado;
            else if (this.Siguiente != null)
                this.Siguiente.Aprobar(prestamo);
            else
                prestamo.Estado = EstadoAprobacion.Desaprobado;
        }
    }
}
