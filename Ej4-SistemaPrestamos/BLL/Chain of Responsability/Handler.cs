using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Chain_of_Responsability
{
    public abstract class Handler
    {
        public Handler Siguiente { get; set; }

        public abstract void Aprobar(Prestamo prestamo);


        public void SetSiguiente(Handler handler)
        {
            this.Siguiente = handler;
        }
    }
}
