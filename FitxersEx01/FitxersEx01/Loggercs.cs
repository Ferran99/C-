using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FitxersEx01
{
     class Logger 
    {

        public static void Write()
        {
            string textEscrit;
            DateTime dataActual;
            string nomDelFitxer;
            Console.WriteLine("Esciru el nom del fitxer que vols esciure: ");
            nomDelFitxer = Console.ReadLine();
            nomDelFitxer = nomDelFitxer + ".txt";

            if (!File.Exists(nomDelFitxer))
            {
                Console.WriteLine("Esciru el text que vulguis: ");
                textEscrit = Console.ReadLine();
                dataActual = DateTime.Now;
                File.WriteAllText(nomDelFitxer, textEscrit + "\nHora de creació: " + dataActual);

            }
            else
            {
                Console.WriteLine("error, El fitxer ja existeix");
                
            }

        }
    }
}
