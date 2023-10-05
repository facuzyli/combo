using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchadores
{
    public class ManejadorMemento
    {
        private Stack<Memento> MementoStack { get; set; }

        public ManejadorMemento()
        {
            MementoStack = new Stack<Memento>();
        }


        public void SetMemento(Memento memento)
        {
            MementoStack.Push(memento);
        }

        public Memento GetMemento()
        {
            if (MementoStack.Count > 0)
            {
                return MementoStack.Pop();
            }
            else
            {
                return null;
            }
        }

        //public Memento Memento
        //{
        //    set 
        //    {
        //        MementoStack.Push(value); 
        //    }
        //    get 
        //    {
        //        if(MementoStack.Count > 0)
        //        {
        //            return MementoStack.Pop();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
