using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculation
{
    public abstract class Shape
    {
        public abstract double CalculateArea(); // Alan Hesaplama
        public abstract double CalculatePerimeter(); // Çevre Hesaplama
        public abstract string ShapeName();// Şekil Adı

    }

}
