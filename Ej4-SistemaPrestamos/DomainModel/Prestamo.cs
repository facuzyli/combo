using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Prestamo
    {
        public decimal Monto { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public Cliente Cliente { get; set; }

        public EstadoAprobacion Estado { get; set; }

        public Prestamo()
        {
            this.Estado = EstadoAprobacion.Solicitado;
        }
    }
}
