using System;

namespace Exercici1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double nota;
            do
            {
                Console.WriteLine("Nota a introduir (per finalitzar premeu el numero 11: ");
                nota = double.Parse(Console.ReadLine());


                if (nota < 5)
                {
                    Console.WriteLine("Alumne Suspés");
                }
                else if (nota >= 5 && nota < 6)
                {
                    Console.WriteLine("Ha obtingut un suficient");

                }
                else if (nota >= 6 && nota < 7)
                {
                    Console.WriteLine("Ha obtingut un bé");

                }
                else if (nota >= 7 && nota < 9)
                {
                    Console.WriteLine("Ha obtingut un notable");

                }
                else if (nota >= 9 && nota <= 10)
                {
                    Console.WriteLine("Ha obtingut un exelent");

                }
            } while (nota != 11);
            
        }
    }
}
