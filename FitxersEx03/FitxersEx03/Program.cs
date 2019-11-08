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
            StreamReader s = new StreamReader(@"C:\Users\La Llucana\source\repos\FitxersEx02\FitxersEx02\bin\Debug\netcoreapp2.1\Ferran.txt");
            string currentLine;
            string searchString = Console.ReadLine().ToLower() ;
            bool foundText = false;
            int count = 0;
            
                do
                {
                    currentLine = s.ReadLine();
                    if (currentLine != null)
                    {
                        foundText = currentLine.Contains(searchString);
                    }
                if (foundText)
                {
                    count++;
                }
            }
                while (currentLine != null);

            Console.WriteLine(searchString + ": " + count);

               
            
           
        }
    }
}
