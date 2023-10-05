namespace Test_Reflection
{
    using System;

    public class Persona
    {
        private string _apellido;
        private string _nombre;

        //private Persona()
        //{

        //}

        public Persona()
        {
                
        }
        //public Persona(string apellido, string nombre)
        //{
        //    this._apellido = apellido;
        //    this._nombre = nombre;
        //}

        public void Saludar()
        {
            Console.WriteLine("Test_Reflection.dll::Public Sub Saludar()");
        }

        public void Saludar(string valor)
        {
            Console.WriteLine("Test_Reflection.dll::Public Sub Saludar() " + valor);
        }

        private void SaludarDos()
        {
            Console.WriteLine("Test_Reflection.dll::Private Sub SaludarDos()");
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
    }
}

