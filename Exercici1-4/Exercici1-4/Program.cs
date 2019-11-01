using System;

namespace Exercici1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOrdinador = new Random().Next(1, 51);
            bool isDificultat = false;
            int numIntents = 0;
            int dificlutat;
            int numUsuari;
           

            do
            {
                Console.WriteLine("Si la dificultat és facil tindràs 30 intents, sí es mitjana 20 i dificil un número de 10 \n");
                Console.WriteLine("Dificlutat: (Facil: 1, Mitjana: 2 Dificil:3 ): \n");
                dificlutat = int.Parse(Console.ReadLine());
                if (dificlutat == 1)
                {
                    Console.WriteLine("Has seleccionat dificultat fàcil..");
                    isDificultat = true;
                    numIntents = 30;
                }
                else if (dificlutat == 2)
                {
                    Console.WriteLine("Has seleccionat dificultat mitjana..");
                    isDificultat = true;
                    numIntents = 20;

                }
                else if (dificlutat == 3)
                {
                    Console.WriteLine("Has seleccionat dificultat dificil ..");
                    isDificultat = true;
                    numIntents = 10;

                }
                else
                {
                    Console.WriteLine("Has de seleccionar un numero del 1 al 3 segons la dificlutat sent 3 la més complicada\n ..");
                   
                }
            } while (isDificultat != true);
            do
            {
                isDificultat = false;
                Console.WriteLine("Ordinador: " + numOrdinador + "\n");
                Console.WriteLine("Quin número creus que he pensat (és un número entre 1 i el 50)....\n");
                numUsuari = int.Parse(Console.ReadLine());
                if (numUsuari == numOrdinador)
                {
                    Console.WriteLine("Molt bé, has guanyat!!");
                    isDificultat = true;
                }
                else
                {
                    Console.WriteLine("Et queden: " + numIntents + "\n");
                    numIntents--;
                }
            } while ( isDificultat != true || numIntents == 0);
            
        }
    }
}
