using System;

namespace HerènciaEx_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrat q1 = new Quadrat(10.5);
            q1.calculaArea();
            q1.calcularPerimetre();

            Rectangle r1 = new Rectangle(1.5, 3);
            r1.calculaArea();
            r1.calcularPerimetre();

            Triangle t1 = new Triangle(2, 4);
            t1.calculaArea();
            t1.calcularPerimetre();

            Cercle c1 = new Cercle(2);
            c1.calculaArea();
            c1.calcularPerimetre();

        }
    }
}
