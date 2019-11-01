using System;
using System.Collections.Generic;
using System.Text;

namespace HerènciaEx_03
{
    class Triangle : Poligon
    {
        private double _base;
        private double altura;

        public Triangle(double @base, double altura):base()
        {
            this.Base = @base;
            this.Altura = altura;
        }

        public double Altura { get => altura; set => altura = value; }
        public double Base { get => _base; set => _base = value; }

        public override void calculaArea()
        {
            double area = this._base * this.altura;
            this.Area = area;
            Console.WriteLine("L'area del triangle és " + this.Area + "cm");
            Console.ReadLine();
        }

        public override void calcularPerimetre()
        {
            double perimetre = Math.Sqrt( Math.Pow(2, this._base) + Math.Pow(2, this.altura));
            this.Perimetre = perimetre;
            Console.WriteLine("El perimetre del rectangle és " + this.Perimetre + "cm");
            Console.ReadLine();
        }
    }
    


}
