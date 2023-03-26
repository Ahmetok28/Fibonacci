// See https://aka.ms/new-console-template for more information
using Circle;

Console.WriteLine("Lütfen çizmek istediğiniz dairenin yarı çapını yazınız:");

int radius= Convert.ToInt32(Console.ReadLine());

CircleDrawer drawer= new CircleDrawer();
drawer.DrawCircle(radius);