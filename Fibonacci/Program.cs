// See https://aka.ms/new-console-template for more information
using Fibonacci;

Console.WriteLine("Derinlik Giriniz");
int depth = Convert.ToInt32(Console.ReadLine());
FibonacciGenerator generator = new FibonacciGenerator();
int[] series = generator.Generate(depth);
AverageCalculator calculator = new AverageCalculator();
double average = calculator.CalculateAverage(series);

Console.WriteLine("Fibonacci serisindeki sayıların ortalaması: " + average);
