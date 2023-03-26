using AreaCalculation;


Console.WriteLine("Lütfen hesaplamak istediğiniz şekli seçin:");
Console.WriteLine("1 - Daire");
Console.WriteLine("2 - Kare");
Console.WriteLine("3 - Üçgen");
Console.WriteLine("4 - Dikdörtgen");

int shapeChoice = int.Parse(Console.ReadLine());

Shape shape;
switch (shapeChoice)
{
    case 1:
        shape = new Circle();
        Console.Write("Dairenin yarıçapını girin: ");
        ((Circle)shape).Radius = double.Parse(Console.ReadLine());
        break;
    case 2:
        shape = new Square();
        Console.Write("Karenin kenar uzunluğunu girin: ");
        ((Square)shape).SideLength = double.Parse(Console.ReadLine());
        break;
    case 3:
        shape = new Triangle(); 
        Console.Write("Üçgenin ilk kenar uzunluğunu girin: ");
        ((Triangle)shape).SideA = double.Parse(Console.ReadLine());
        Console.Write("Üçgenin ikinci kenar uzunluğunu girin: ");
        ((Triangle)shape).SideB = double.Parse(Console.ReadLine());
        Console.Write("Üçgenin üçüncü kenar uzunluğunu girin: ");
        ((Triangle)shape).SideC = double.Parse(Console.ReadLine());
        break;
    case 4:
        shape = new Rectangle();
        Console.Write("Dikdörtgenin uzun kenar uzunluğunu girin: ");
        ((Rectangle)shape).Length = double.Parse(Console.ReadLine());
        Console.Write("Dikdörtgenin kısa kenar uzunluğunu girin: ");
        ((Rectangle)shape).Width = double.Parse(Console.ReadLine());
        break;
    default:
        Console.WriteLine("Hatalı seçim. Program sonlandırılıyor.");
        return;
}

Console.WriteLine("Lütfen hesaplamak istediğiniz boyutu seçin:");
Console.WriteLine("1 - Alan");
Console.WriteLine("2 - Çevre");
int calculationChoice = int.Parse(Console.ReadLine());
string name = shape.ShapeName().Substring(shape.ShapeName().Length - 1);
switch (calculationChoice)
{    
    case 1:
        if (name=="n")
        {
            Console.WriteLine(shape.ShapeName() + "'in Alanı = " + shape.CalculateArea() + " birim\u00B2.");
            break;
        }
        else
        {
            Console.WriteLine(shape.ShapeName() + "'nin Alanı = " + shape.CalculateArea() + " birim\u00B2.");
            break;

        }
       

    case 2:
        if (name == "n")
        {
            Console.WriteLine(shape.ShapeName() + "'in Çevresi = " + shape.CalculatePerimeter() + " birim.");

            break;
        }
        else
        {
            Console.WriteLine(shape.ShapeName() + "'nin Çevresi = " + shape.CalculatePerimeter() + " birim.");

            break;
        }
        

    default:
        Console.WriteLine("Hatalı seçim. Program sonlandırılıyor.");
        return;
}

Console.WriteLine("");



