using System;
using System.Collections.Generic;
using System.Text;

namespace Herència
{
    class Cotxe : Vehicle
    {
        private  String numBestidor;

        public Cotxe(string numBestidor, string color, string marca, string model):base(color, marca, model)
        {
            this.numBestidor = numBestidor;
            this.color = color;
            this.marca = marca;
            this.model = model;
        }

        public override void vSaludar()
        {
            Console.WriteLine("bufffffff......");
        }
    }

    
}
