using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Ex001
{
    class Estudiant : Persona
    {
        private bool anarClasse;

        public Estudiant(bool anarClasse, int age, string name, int size):base(age,name,size)

        {
            this.anarClasse = anarClasse;
            this.age = age;
            this.name = name;
            this.size = size;
        }

        public void mostrarEdat()
        {
            Console.WriteLine("La meva edat: "+ age);
        }

        public void anarAClasse()
        {
            Console.WriteLine("Estic anant a classe");
        }

        public override void saludar()
        {
            Console.WriteLine("Soc un estudiant...");
        }

    }
}
