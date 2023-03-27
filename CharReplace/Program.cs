Console.Write("Lüften bir metin giriniz: ");
string input = Console.ReadLine();
string output = "";
string[] strings = input.Split(" ");

foreach (var word in strings)
{
    char[] chars = word.ToCharArray();
    char first = chars[0];
    char last = chars[chars.Length - 1];
    chars[0] = last;
    chars[chars.Length - 1]=first;

    output += new string(chars) + " ";



}
Console.Write("Output: " + output);