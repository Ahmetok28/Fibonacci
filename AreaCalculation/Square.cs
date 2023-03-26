namespace AreaCalculation
{
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override double CalculateArea()
        {
            return SideLength * SideLength;
        }

        public override double CalculatePerimeter()
        {
            return 4 * SideLength;
        }
        public override string ShapeName()
        {
            return "Kare";
        }
    }

}
