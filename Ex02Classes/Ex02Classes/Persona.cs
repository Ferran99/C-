using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02Classes
{
    class Persona
    {
        protected int age;
        protected String name;
        protected int size;

        public Persona(int age, string name, int size)
        {
            this.age = age;
            this.name = name;
            this.size = size;
        }


        public int Age
        {
            get { return age; }
            set { age = value; }

        }

        public virtual void saludar()
        {
            Console.WriteLine("Et saluda una Persona");
        }
    }
}
