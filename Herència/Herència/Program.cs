using System;

namespace Herència
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle c1 = new Cotxe("1234567fd","Blau","Nissan","Leaf");
            Vehicle v1 = new Vehicle("vermell", "Seat", "Ibiza");
            c1.vSaludar();
            v1.vSaludar();
        }
    }
}
