using System;
using System.Collections.Generic;
using System.Text;

namespace HerènciaEx_03
{
    class Cercle : Poligon
    {
        private double radi;

        public Cercle(double radi):base()
        {
            this.radi = radi;
        }

        public double Radi { get => radi; set => radi = value; }

        public override void calculaArea()
        {
             double area = Math.PI * Math.Pow(2, this.radi);
            this.Area = area;

            Console.WriteLine("L'area de la circunnferència és " + this.Area + "cm");
            Console.ReadLine();
        }

        public override void calcularPerimetre()
        {
            double perimetre = (2 * Math.PI ) * this.radi;
            this.Perimetre = perimetre;
            Console.WriteLine("El perimetre de la circunnferència és " + this.Perimetre + "cm");
            Console.ReadLine();

        }
    }


}
