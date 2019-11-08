using System;
using System.Collections;
using System.IO;
namespace FitxersEx02
{
    class Program
    {
        static void Main(string[] args)
        {
           /* for(int i = 0; i <= 100; i++)
            {
                File.AppendAllText("Ferran.txt","linia: " +i+"\n");
            }*/
            int line = 27;
            int lActual = 0;
            if (line > (File.ReadAllLines("Ferran.txt").Length - 1))
            {
                line = (File.ReadAllLines("Ferran.txt").Length - 1);
                Console.WriteLine("Atenció el fitxer té menys de 27 línies!! ("+ (line+1) + ")");

                
            }
                for (int i = 0; i <= line; i++)
            {
                string resultado = File.ReadAllLines("Ferran.txt")[i];
                Console.WriteLine(resultado);
                lActual = i;
            }
            

            do
            {
                int ProximaLinia = lActual + 27;

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                   


                    if (ProximaLinia > (File.ReadAllLines("Ferran.txt").Length - 1))

                    {
                        if(lActual < (File.ReadAllLines("Ferran.txt").Length - 1))
                        {
                            Console.WriteLine("Llegint últimes línies del fitxer");
                            for (int i = (lActual + 1); i <= (File.ReadAllLines("Ferran.txt").Length -1 ); i++)
                            {
                                string resultado = File.ReadAllLines("Ferran.txt")[i];
                                Console.WriteLine(resultado);
                                lActual = i;
                            }
                        }else
                        {
                            Console.WriteLine("S'ha llegit totes les linies del fitxer");

                        }


                    } else if(ProximaLinia == (File.ReadAllLines("Ferran.txt").Length - 1))
                    {
                        if (lActual < (File.ReadAllLines("Ferran.txt").Length - 1))
                        {
                            for (int i = (lActual + 1); i <= (File.ReadAllLines("Ferran.txt").Length - 1); i++)
                            {
                                string resultado = File.ReadAllLines("Ferran.txt")[i];
                                Console.WriteLine(resultado);
                                lActual = i;
                            }
                        }else
                        {
                            Console.WriteLine("S'ha llegit totes les linies del fitxer");

                        }

                    }
                    else
                    {
                        for(int i = (lActual + 1); i <= ProximaLinia; i++)
                        {
                            string resultado = File.ReadAllLines("Ferran.txt")[i];
                            Console.WriteLine(resultado);
                            lActual = i;
                        }
                    }
                }


            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
