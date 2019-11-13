using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            String paraulesResultants = "";
            Dictionary<String, int> tematica = new Dictionary<string, int>();
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
                tematica = szTematica(rutaDelFitxer);

                var NumordenatsPelValor = from element in tematica
                                                  orderby element.Value
                                                  descending
                                                  select element;
                int nMax = 0;
                foreach (KeyValuePair<String, int> item in NumordenatsPelValor)
                {
                    // Console.WriteLine("{0} Value: {1}", item.Key, item.Value);
                    paraulesResultants += item.Key + ", ";
                    nMax++;
                    if (nMax == 5)
                    {
                        break;
                    }
                }
                Console.WriteLine("Temàtica: " + paraulesResultants);

                foreach (KeyValuePair<String, int> item in NumordenatsPelValor)
                {
                    Console.WriteLine("{0} Value: {1}", item.Key, item.Value);

                }
              

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
            string delimitador = ", . ? ¿ ! ¡ : ; "; 
            string[] paraulesLinia = null;
            string linia = null;

            while (!sr.EndOfStream)
            {
                linia = sr.ReadLine();
                linia.Trim();
                paraulesLinia = linia.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                paraulesLinia = linia.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                nComptador += paraulesLinia.Length; 
            }


            return nComptador;
        }

        public static Dictionary<String, int> szTematica(String nomFitxer)
        {
            Dictionary<String, int> tematica = new Dictionary<String, int>();
            string sr = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", nomFitxer));
            string delimitador = ",.?¿!¡:;.. ";
            string fitxerParaulesProhibides = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", "paraulesProhibides.txt"));
            string[] paraulesProhibides = null;
            string[] paraulesLinia = null;
         

            fitxerParaulesProhibides = treureAccents(fitxerParaulesProhibides);
            sr = treureAccents(sr);
            
            paraulesLinia = sr.Split(" ");
            fitxerParaulesProhibides = fitxerParaulesProhibides.ToLower();
            paraulesProhibides = fitxerParaulesProhibides.Split("\n");
            
            for(int i = 0; i < paraulesLinia.Length; i++)
            {
               

                paraulesLinia[i] = paraulesLinia[i].ToLower();
                paraulesLinia[i] = CleanInput(paraulesLinia[i]);
                paraulesLinia[i] = paraulesLinia[i].Trim(new Char[] { ' ', '*', '.', ',', '!', '¡', '¿', '?' });
                /* for (int x = 0; x< delimitador.Length; x++)
                  {
                      paraulesLinia[i] = paraulesLinia[i].TrimEnd(delimitador[x]);
                      paraulesLinia[i] = paraulesLinia[i].TrimStart(delimitador[x]);
                      paraulesLinia[i] = paraulesLinia[i].Trim(new Char[] { '*', '.',',','!','¡','¿','?' });


                  }*/


                if (tematica.ContainsKey(paraulesLinia[i]))
                {
                    tematica[paraulesLinia[i]] = tematica[paraulesLinia[i]] + 1;
                }
                else
                {
                    if (!fitxerParaulesProhibides.Contains(paraulesLinia[i]))
                    {
                        tematica.Add(paraulesLinia[i], 1);

                    }
                    

                }




            }

            
            

            return tematica;
        }

        public static string treureAccents(String text)
        {
            string ambSignes = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            string senseSignes = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcC";

            StringBuilder textSenseAccents = new StringBuilder(text.Length);
            int ambAccent;
            foreach (char caracter in text)
            {
                ambAccent = ambSignes.IndexOf(caracter);
                if (ambAccent > -1)
                    textSenseAccents.Append(senseSignes.Substring(ambAccent, 1));
                else
                    textSenseAccents.Append(caracter);
            }
            return textSenseAccents.ToString();
        }

        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                if (strIn.Contains("d'") || strIn.Contains("l'"))
                {
                    string cadena = null;
                    cadena = Regex.Replace(strIn, @"[^\w]", "",
                                         RegexOptions.None, TimeSpan.FromSeconds(1.5));

                    return cadena.Substring(1);
                }
                else
                {
                    return strIn;
                }
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }




    }
}
