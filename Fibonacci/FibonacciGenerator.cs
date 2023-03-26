using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciGenerator
    {
        public int[] Generate(int depth)
        {
            int[] series = new int[depth];
            if (depth >= 1)
            {
                series[0] = 0;
            }
            if (depth >= 2)
            {
                series[1] = 1;
            }
            for (int i = 2; i < depth; i++)
            {
                series[i] = series[i - 1] + series[i - 2];
            }
            return series;
        }
    }
}
