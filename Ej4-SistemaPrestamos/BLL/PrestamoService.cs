using BLL.Chain_of_Responsability;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PrestamoService
    {
        private static Handler ejecutivo;


        private static Handler lider;


        private static Handler gerente;

        static PrestamoService()
        {
            lider = new Lider();
            ejecutivo = new EjecutivoCuenta();
            gerente = new Gerente();
            ejecutivo.SetSiguiente(lider);
            lider.SetSiguiente(gerente);
        }

        public static void Aprobar(Prestamo prestamo)
        {
            ejecutivo.Aprobar(prestamo);
        }
    }
}
