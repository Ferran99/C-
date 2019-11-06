using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestEx01
{
    class Multiple
    {
        public static ArrayList Multiples(int i)
        {
            ArrayList multiples = new ArrayList();
            for(int num = 0; num <= i; num++)
            {
                if(num % 3 == 0 && num % 5 == 0)
                {
                    multiples.Add("BooomPaaaam");
                }else if(num % 3 == 0)
                {
                    multiples.Add("Booom");
                }else if (num % 5 == 0)
                {
                    multiples.Add("Paaaam");
                }
                else
                {
                    multiples.Add(num.ToString());
                }
            }
            return multiples;
        }
    }
}
