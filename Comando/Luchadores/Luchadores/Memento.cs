using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchadores
{
    public class Memento
    {
        private int _salud;

        public Memento(int salud)
        {
            this._salud = salud;
        }

        public int Salud
        {
            get { return _salud; }
        }
    }
}
