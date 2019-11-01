using System;
using System.Collections.Generic;
using System.Text;

namespace Herència
{
    class Vehicle
    {
        protected String color;
        protected String marca;
        protected String model;

        public Vehicle(string color, string marca, string model)
        {
            this.color = color;
            this.marca = marca;
            this.model = model;
        }

        public virtual void vSaludar()
        {
            Console.WriteLine("Saluda vehicle");
        }


    }
}
