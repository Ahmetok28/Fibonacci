using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucgen
{
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(int size) : base(size)
        {
        }

        public override void Draw()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j < size - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i * 2; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
           
        }
    }
}
