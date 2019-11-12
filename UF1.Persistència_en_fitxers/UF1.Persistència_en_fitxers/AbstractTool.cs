using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace UF1.Persistència_en_fitxers
{
    abstract class AbstractTool
    {
        public static void vComprovaDirectori()
        {
            string nomDirectori = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool");
            if (Directory.Exists(nomDirectori))
            {
                Console.WriteLine("El directori ja existeix.");
                Console.WriteLine("Dipositi els fitxers que vols procesar en el directori: "+nomDirectori);
                Console.WriteLine("Quan estigui, prem-hi la tecla enter...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Creant directori " + nomDirectori);
                Directory.CreateDirectory(nomDirectori);
                Console.WriteLine("Directori creat correctament");
                Console.WriteLine("Dipositi els fitxers que vols procesar en el directori: " + nomDirectori);
                Console.WriteLine("Quan estigui, prem-hi la tecla enter...");
                Console.ReadLine();
            }
            vLlegeixFitxer();
        }

        public static void vLlegeixFitxer()
        {
            Console.WriteLine("Indica el nom del fitxer que vols processar: ");
            string nomFitxer = Console.ReadLine();
            string rutaDelFitxer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", nomFitxer);
            if(File.Exists(rutaDelFitxer))
                {
                string nomFitxerSenseExtencio = szNomDelFitxer(nomFitxer);
                string extencioFitxer = szExtencioDelFitxer(nomFitxer);
                Console.WriteLine("Nom del fitxer: " + nomFitxerSenseExtencio);
                Console.WriteLine("Exstenció del fitxer: " + extencioFitxer);
                DateTime dataDeCreacio = dateDataCracio(rutaDelFitxer);
                Console.WriteLine("Data: " + dataDeCreacio);
                int numParaules = nNumParaules(rutaDelFitxer);
                Console.WriteLine("Numero de paraules: " + numParaules);
                szTematica(rutaDelFitxer);

            }
            else
            {
                Console.WriteLine("El fitxer no existeix, siuplau torna a introduir el nom d'un fitxer valid");
                vLlegeixFitxer();
            }
           

        }

        public static String szNomDelFitxer(string nomDelFitxer)
        {
            return Path.GetFileNameWithoutExtension(nomDelFitxer);
        }

        public static String szExtencioDelFitxer(string extencio)
        {
            return Path.GetExtension(extencio);
        }

        public static DateTime dateDataCracio(string nom)
        {
            return File.GetCreationTimeUtc(nom);
        }

        public static int nNumParaules(string nomFitxer)
        {
            StreamReader sr = new StreamReader(nomFitxer);

            int nComptador = 0;
            string delimitador = ", . ? ¿ ! ¡ : ; "; //maybe some more delimiters like ?! and so on
            string[] paraulesLinia = null;
            string linia = null;

            while (!sr.EndOfStream)
            {
                linia = sr.ReadLine();//each time you read a line you should split it into the words
                linia.Trim();
                paraulesLinia = linia.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                paraulesLinia = linia.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                nComptador += paraulesLinia.Length; //and just add how many of them there is
            }


            return nComptador;
        }

        public static /*Dictionary<String, int>*/ void szTematica(String nomFitxer)
        {
            Dictionary<String, int> tematica = new Dictionary<String, int>();
            StreamReader sr = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", nomFitxer));
            string linia = null;
            string[] delimitador = null;
            int nComptador = 0;
            string[] paraulesLinia = null;
            delimitador = File.ReadAllLines(nomFitxer);
            while (!sr.EndOfStream)
            {
                linia = sr.ReadLine();//each time you read a line you should split it into the words
                                      // linia.Trim();
                paraulesLinia = linia.Split(" ");

                for (int i = 0; i< paraulesLinia.Length; i++)
                {
                    Console.WriteLine(paraulesLinia[i]);
                    for(int x = 0; x < delimitador.Length; x++)
                    {
                        if(paraulesLinia[i][paraulesLinia.Length-1]==)
                    }

                }
            }
           


           // return tematica;
        }





    }
}
