using System;
using System.IO;
namespace FitxersEx02
{
    class Program
    {
        static void Main(string[] args)
        {
            int l;
            int total;

            using (StreamReader r = new StreamReader("Ferran.txt"))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                total = i;
            }
            GetLine(fileName: "Ferran.txt", line: 27, variable: 1);

            void GetLine(string fileName, int line, int variable)
            {
                using (var sr = new StreamReader(fileName))
                {
                    int i =  0;
                    for ( i = variable ; i <= line; i++)
                        
                    Console.WriteLine(sr.ReadLine());
                    l = i;
                }
            }

            do
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    int a = l + 27;
                    if (a > total)

                    {
                        a = total - a;
                        if (a <= 0) {
                            Console.WriteLine("S'ha llegit totes les linies del fitxer");
                        }else
                        {
                            GetLine(fileName: "Ferran.txt", line: a, variable: 1);

                        }
                    }
                    else
                    {
                        GetLine(fileName: "Ferran.txt", line: a, variable: 1);
                    }
                }


            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
