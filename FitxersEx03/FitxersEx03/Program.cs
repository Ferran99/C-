using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FitxersEx03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paraula a buscar: ");
            string s = "D:\\C-\\FitxersEx02\\FitxersEx02\\bin\\Debug\\netcoreapp2.1\\Ferran.txt";
            string currentText;
            string searchString = Console.ReadLine().ToLower() ;
            int count = 0;
            String[] Words;
            currentText = File.ReadAllText(s);
            Words = currentText.Split(" ");

            for(int i = 0; i<= (Words.Length -1); i++)
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

            }




        }
    }
}
