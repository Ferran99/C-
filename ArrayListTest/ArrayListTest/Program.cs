using System;
using System.Collections;

namespace ArrayListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 15;
            ArrayList multiples = new ArrayList();
            for (int num = 0; num <= i; num++)
            {
                if (num % 3 == 0 && num % 5 == 0)
                {
                    multiples.Add("BooomPaaaam");
                }
                else if (num % 3 == 0)
                {
                    multiples.Add("Booom");
                }
                else if (num % 5 == 0)
                {
                    multiples.Add("Paaaam");
                }
                else
                {
                    multiples.Add(num.ToString());
                }
                Console.WriteLine(multiples[num]);

            }

        }
    }
}
