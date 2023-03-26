namespace AreaCalculation
{
    public class Triangle : Shape
    {
       
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
        public override string ShapeName()
        {
            return "Üçgen";
        }

        public override double CalculateArea()
        {
            double semiPerimeter = CalculatePerimeter() / 2;
            if (semiPerimeter - SideA < 0)
            {
                throw new Exception("a kenarı b ve c kenarlarından çok daha uzun.");
                   
            }
            if (semiPerimeter - SideB < 0)
            {
                throw new Exception("b kenarı a ve c kenarlarından çok daha uzun.");
                   
            }
            if (semiPerimeter - SideC < 0)
            {
                throw new Exception("c kenarı a ve b kenarlarından çok daha uzun.");
                   
            }

            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
            return area;
        }
    }

}
