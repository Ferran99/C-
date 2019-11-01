using System;
using System.Collections.Generic;
using System.Text;

namespace HerènciaEx_03
{
    class Quadrat : Poligon
    {
        private double costat;

        protected double Costat { get => costat; set => costat = value; }

        public Quadrat(double costat):base()
        {
            this.costat = costat;
        }

        public override void calculaArea()
        {
            double area = this.costat * this.costat;
            this.Area = area;
            Console.WriteLine("L'area del quadrat és " + this.Area + "cm");
            Console.ReadLine();
        }

        public override void calcularPerimetre()
        {
            double perimetre = 4 * this.costat;
            this.Perimetre = perimetre;
            Console.WriteLine("El perimetre del quadrat és " + this.Perimetre + "cm");
            Console.ReadLine();

        }
    }
}
