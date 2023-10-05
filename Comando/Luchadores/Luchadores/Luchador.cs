using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchadores
{
    public class Luchador
    {
        private int _velocidad;
        private int _salud;
        private int _golpesSeguidos;
        private ManejadorMemento _manejadorMemento;

        public int Velocidad
        {
            get
            {
                return _velocidad;
            }
            set
            {
                _velocidad = value;
            }
        }

        public int Salud
        {
            get
            {
                return _salud;
            }
            set
            {
                _salud = value;
            }
        }

        public int GolpesSeguidos
        {
            get
            {
                return _golpesSeguidos;
            }
            set
            {
                _golpesSeguidos = value;
            }
        }

        public Luchador()
        {
            Random rand = new Random();

            _velocidad = rand.Next(0,10);
            _salud = 100;
            _manejadorMemento = new ManejadorMemento();
        }

        public void darGolpe(Golpe golpe, Luchador luchadorGolpeado)
        {
            _golpesSeguidos++;
            luchadorGolpeado.quitarSalud(golpe);

            if(_golpesSeguidos == 5)
            {
                Console.WriteLine("Recuperando vida...");
                _golpesSeguidos = 0;
                this.SetMemento(_manejadorMemento.GetMemento());
            }
        }

        public void quitarSalud(Golpe golpe)
        {
            _golpesSeguidos = 0; //Reinicia el contador de golpes seguidos...
            _manejadorMemento.SetMemento(this.CreateMemento());

            if ((_salud - (int)golpe) > 0)
            {
                _salud -= (int)golpe;
            }
            else
            {
                _salud = 0;
                throw new Exception("Game over");
            }            
        }
                
        private Memento CreateMemento()
        {
            return new Memento(this._salud);
        }
                
        private void SetMemento(Memento memento)
        {
            if(memento != null)
            {
                this._salud = memento.Salud;
            }            
        }
    }
}
