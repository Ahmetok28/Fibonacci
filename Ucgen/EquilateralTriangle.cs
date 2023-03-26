namespace Ucgen
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(int size) : base(size)
        {
        }

        public override void Draw()
        {
            for (int i = 0; i < size; i++) 
            {
                for (int k = i; k < size; k++) 
                {
                    Console.Write(" ");
                }
                for (int x = 0; x <= i; x++)
                {
                    Console.Write("*"); 
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
