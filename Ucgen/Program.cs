// See https://aka.ms/new-console-template for more information


using Ucgen;

Console.Write("Üçgen boyutunu girin: ");
int size = Convert.ToInt32(Console.ReadLine());

Console.Write("Çizmek istediğiniz üçgenin tipini girin (1: Eşkenar, 2: İkizkenar): ");
int type = Convert.ToInt32(Console.ReadLine());

Triangle triangle = null;
if (type == 1)
{
    triangle = new EquilateralTriangle(size);
}
else if (type == 2)
{
    triangle = new IsoscelesTriangle(size);
}
else
{
    Console.WriteLine("Geçersiz üçgen tipi");
    return;
}

triangle.Draw();