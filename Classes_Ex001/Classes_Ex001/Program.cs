using System;

namespace Classes_Ex001
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona(18, "Marc", 180);
            Professor ps1 = new Professor("C#", 32, "Hèctor", 180);
            Estudiant e1 = new Estudiant(true, 21, "Eloi", 179);

            p1.saludar();
            e1.saludar();
            e1.mostrarEdat();
            ps1.saludar();
            ps1.Explicar();

        }
    }
}
