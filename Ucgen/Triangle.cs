namespace Ucgen
{
    public abstract class Triangle
    {
        protected int size;

        public Triangle(int size)
        {
            this.size = size;
        }

        public abstract void Draw();
    }
}
