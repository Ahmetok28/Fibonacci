namespace Ucgen
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(int size) : base(size)
        {
        }

        public override void Draw()
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
