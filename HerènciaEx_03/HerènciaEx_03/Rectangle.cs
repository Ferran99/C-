using System;
using System.Collections.Generic;
using System.Text;

namespace HerènciaEx_03
{
    class Rectangle : Poligon
    {
        private double _base;
        private double altura;

        public double Base { get => _base; set => _base = value; }
        public double Altura { get => altura; set => altura = value; }

        public Rectangle(double @base, double altura):base()
        {
            this._base = @base;
            this.altura = altura;
        }

        public override void calculaArea()
        {
            double area = this._base * this.altura;
            this.Area = area;
            Console.WriteLine("L'area del rectangle és " + this.Area + "cm");
            Console.ReadLine();
        }

        public override void calcularPerimetre()
        {
            double perimetre = ( 2 * this._base ) + (2 * this.altura);
            this.Perimetre = perimetre;
            Console.WriteLine("El perimetre del rectangle és " + this.Perimetre + "cm");
            Console.ReadLine();
        }
    }

    


}
