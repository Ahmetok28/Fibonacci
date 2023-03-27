

Console.WriteLine("Lütfen değerleri girin:");
string input = Console.ReadLine();

string[] values = input.Split(' ');

int smalller = 0;
int greater = 0;

foreach (var item in values)
{
    int num = int.Parse(item);
    if (num < 67)
    {
        smalller += 67 - num;
    }
    else
    {
        greater += (num - 67) * (num - 67);
    }
}
Console.WriteLine(smalller+" "+greater);

