using System;
using System.Collections.Generic;
using System.Text;

namespace HerènciaEx_03
{
    abstract  class Poligon
    {
        protected double area;
        protected double perimetre;

        protected double Area { get => area; set => area = value; }
        protected double Perimetre { get => perimetre; set => perimetre = value; }

        protected Poligon()
        {
        }

        public abstract void calculaArea();
        public abstract void calcularPerimetre();


    }
}
