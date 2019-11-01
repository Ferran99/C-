using System;

namespace Exercici1_3
{
    class Program
    {

        static void Main(string[] args)
        {
            var rand = new Random();

            int i = 0;
            while(i <= 50)
            {
                var num = rand.Next(1, 7);
                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(num + "\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(num + "\n");
                }
                i++;
            }
        }
    }
}
