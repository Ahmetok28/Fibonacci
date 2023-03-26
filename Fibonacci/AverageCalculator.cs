namespace Fibonacci
{
    public class AverageCalculator
    {
        public double CalculateAverage(int[] series)
        {
            int sum = 0;
            for (int i = 0; i < series.Length; i++)
            {
                sum += series[i];
            }
            double average = (double)sum / series.Length;
            return average;
        }
    }
}
