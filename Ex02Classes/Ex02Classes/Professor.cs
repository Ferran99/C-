using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02Classes
{
    class Professor : Persona
    {
        private String materia;

        public Professor(string materia, int age, string name, int size) : base(age, name, size)

        {
            this.materia = materia;
            this.age = age;
            this.name = name;
            this.size = size;
        }

        public void Explicar()
        {
            Console.WriteLine("Comença la explicació");
        }

        public override void saludar()
        {
            Console.WriteLine("Soc un professor..");
        }
    }
}
