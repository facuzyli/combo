using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Tarea
    {
        private string _nombre;

        private string _descripcion;

        private DateTime _fechaFin;

        public Tarea(string pNombre, string pDescripcion, DateTime pFechaFin)
        {
            _nombre = pNombre;
            _descripcion = pDescripcion;
            _fechaFin = pFechaFin;
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return _fechaFin;
            }
            set
            {
                _fechaFin = value;
            }
        }
    }
}
