using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace FitxersEx03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paraula a buscar: ");
            string s = "C:\\Users\\La Llucana\\source\\repos\\FitxersEx02\\FitxersEx02\\bin\\Debug\\netcoreapp2.1\\Ferran.txt";
            string currentText;
            string searchString = Console.ReadLine().ToLower() ;
            int count = 0;
            String[] Words;
            String TextChanged;
            StreamReader currentLine = new StreamReader(s);
            currentText = File.ReadAllText(s);
            Words = currentText.Split(" ");
            string IndexParaules = "";
            String[] IndexParaulesInt = null;
            int index = 0;

            /* for(int i = 0; i<= (Words.Length -1); i++)
             {

                 if (Words[i].ToString().ToLower().Contains(searchString))
                 {

                     count++;
                 }
             }


             if(count > 0)
             {
                 Console.WriteLine(searchString + ": " + count);


             }
             else 
             {
                 Console.WriteLine("La paraula que buscava no està en aquest text");

             }*/
            for(int i = 0; i <= (currentText.Length - 1); i++)
            {
                if(currentText[i] == searchString[0])
                {
                    ComprovaParaula(i);
                    


                }
            }
            IndexParaulesInt = IndexParaules.Split(" ");

            for(int z = 0; z <= (currentText.Length -1 ); z++)
            {
                int newIndex = Int32.Parse(IndexParaulesInt[index]);
                Console.WriteLine(newIndex);
               /* if(currentText[z] == searchString[newIndex])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(currentText[z]);
                    if(index < (IndexParaules.Length - 1))
                    {
                        index++;

                    }
                    else
                    {
                        index = 0;
                    }
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(currentText[z]);

                }*/

            }
           

            void ComprovaParaula(int i)
            {
                int y = i;
                int x = 1;
                if (searchString.Length == 1)
                {


                    if (currentText[y] == searchString[x -1])
                    {


                        count++;


                    }

                }
                else
                {

                    while(x != (searchString.Length + 1 ))
                    {


                        if (currentText[y] == searchString[x -1])
                        {
                            if (x == (searchString.Length ))
                            {

                                count++;
                               
                            }

                            x++;

                        }
                        y++;

                        IndexParaules += y+" ";
                    }
                }
            }
            if (count > 0)
            {
                Console.WriteLine(searchString + ": " + count);


            }
            else
            {
                Console.WriteLine("La paraula que buscava no està en aquest text");

            }




        }
    }
}
