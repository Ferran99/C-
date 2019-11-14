using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace UF1.Persistència_en_fitxers
{
    abstract class AbstractTool
    {
        /// <summary>
        /// Comprova si el directori existeix o no, si no existeix, el crea
        /// </summary>
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

        /// <summary>
        /// Funció principal on es llegeix un fitxer que l'usuari vol analitzar un cop s'ha comprovat el directori
        /// </summary>
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
                    if(nMax != 4)
                    {
                        paraulesResultants += item.Key + ", ";

                    }
                    else
                    {
                        paraulesResultants += item.Key + ".";

                    }
                    nMax++;
                    if (nMax == 5)
                    {
                        break;
                    }
                }
               
                Console.WriteLine("Temàtica: " + paraulesResultants);
                string solucio = "Nom del fitxer: " + nomFitxerSenseExtencio + "\n" + "Exstenció del fitxer: " + extencioFitxer + "\n" + "Data: " + dataDeCreacio + "\n" + "Numero de paraules: " + numParaules + "\n" + "Temàtica: " + paraulesResultants;

                crearFitxer(solucio);
                creacioXML(tematica, nomFitxerSenseExtencio);

              



            }
            else
            {
                Console.WriteLine("El fitxer no existeix, siuplau torna a introduir el nom d'un fitxer valid");
                vLlegeixFitxer();
            }
           

        }

        /// <summary>
        /// Aquesta funció et retorna el nom del fitxer que l'usuari vol analitzar sense l'extenció
        /// </summary>
        /// <param name="nomDelFitxer">Parametre de tipus string on es passa la ruta del fitxer que l'usuari vol analitzar</param>
        /// <returns></returns>
        public static String szNomDelFitxer(string nomDelFitxer)
        {
            return Path.GetFileNameWithoutExtension(nomDelFitxer);
        }

        /// <summary>
        ///  Aquesta funció et retorna l'extenció del fitxer que l'usuari vol analitzar sense el nom
        /// </summary>
        /// <param name="extencio">Parametre on conte el directori on està el fitxer per extreure la seva extenció</param>
        /// <returns></returns>
        public static String szExtencioDelFitxer(string extencio)
        {
            return Path.GetExtension(extencio);
        }
        /// <summary>
        /// Funcio que et retorna la data de creació de l'arxiu passat per paràmetre
        /// </summary>
        /// <param name="nom"> Parametre de tipus string on es passa la ruta del fitxer</param>
        /// <returns></returns>
        public static DateTime dateDataCracio(string nom)
        {
            return File.GetCreationTimeUtc(nom);
        }

        /// <summary>
        /// Funcio que retorna el número de paraules que té el fitxer que l'usuari vol analitzar
        /// </summary>
        /// <param name="nomFitxer"> Parametre de tipus string on es passa la ruta del fitxer que vol analitzar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funció que s'analitza el fitxer que l'usuari vol analitzar i retorna un diccionari de paraules de tipus <Strting, int> on la clau es la paraule obtenida del text i el seu valor és el número de vagades que apareix
        /// </summary>
        /// <param name="nomFitxer">Parametre de tipus string on es passa la ruta del fitxer que vol analitzar</param>
        /// <returns></returns>
        public static Dictionary<String, int> szTematica(String nomFitxer)
        {
            Dictionary<String, int> tematica = new Dictionary<String, int>();
            string sr = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", nomFitxer));
            string delimitador = ",.?¿!¡:;.. \n";
            string fitxerParaulesProhibides = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", "paraulesProhibides.txt"));
            string[] paraulesLinia = null;

            paraulesLinia = sr.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            paraulesLinia = sr.Split(delimitador.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            fitxerParaulesProhibides = fitxerParaulesProhibides.ToLower();
            
            for(int i = 0; i < paraulesLinia.Length; i++)
            {
               

                paraulesLinia[i] = paraulesLinia[i].ToLower();
                paraulesLinia[i] = CleanInput(paraulesLinia[i]);
               


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

        /// <summary>
        /// Funció que serveig per treure els apostrofs del text
        /// </summary>
        /// <param name="strIn">fitxer on es vol treure els apostrofs</param>
        /// <returns></returns>
        static string CleanInput(string strIn)
        {
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
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Funció on es crea un fitxer txt on l'usuari pot veure la tèmatica del text i principals caracteristiques
        /// </summary>
        /// <param name="contingut">Variable on es passa el contingut que es vol escriure al fitxer</param>
        static void crearFitxer(String contingut)
        {
            string rutaDelFitxer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", "Solució.txt");

           
            if (File.Exists(rutaDelFitxer)) {

                File.AppendAllText(rutaDelFitxer, "\n\n" + contingut);
                Console.WriteLine("S'ha afegit les dades noves al fitxer solució");

            }
            else
            {
                File.WriteAllText(rutaDelFitxer, contingut);
                Console.WriteLine("S'han creat un fitxer amb el nom Solució.txt a la carpeta Abstractool del escriptori");

            }

        }
        /// <summary>
        /// Funció encarregada de crear un fitxer XML
        /// </summary>
        /// <param name="diccionari">Variable on es passa un diccionari amb les paraules com a clau i el numero de vegades que apareixen com el seu valor</param>
        /// <param name="nomFitxer">Ruta on es vol guardar el fitxer amb el seu nom</param>
        static void creacioXML(Dictionary<String, int> diccionari, string nomFitxer)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlNode rootNode = xml.CreateElement("Paraules");
                xml.AppendChild(rootNode);


                foreach (KeyValuePair<String, int> item in diccionari)
                {
                                    
                        XmlNode userNode = xml.CreateElement(item.Key);
                        XmlAttribute attribute = xml.CreateAttribute("ocurrències");
                        attribute.Value = item.Value.ToString();
                        userNode.Attributes.Append(attribute);
                        userNode.InnerText = item.Key;
                        rootNode.AppendChild(userNode);
                   
                   


                }

                xml.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AbstracTool", nomFitxer + ".xml" ));
            }
            catch
            {
                Console.WriteLine("Hi ha un error a l'hora de crear el fitxer xml");
            }
        }




    }
}
