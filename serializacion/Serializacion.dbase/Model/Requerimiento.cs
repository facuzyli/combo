using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Requerimiento
    {
        [NonSerialized]
        int _numero;

        string _descripcion;

        List<Tarea> _tareas = new List<Tarea>();

        public Requerimiento(int pNumero, string pDescripcion)
        {
            _numero = pNumero;
            _descripcion = pDescripcion;
        }

        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
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

        public void AddTarea(Tarea unaTarea)
        {
            _tareas.Add(unaTarea);
        }

        public List<Tarea> GetTareas()
        {
            return _tareas;
        }
    }
}
