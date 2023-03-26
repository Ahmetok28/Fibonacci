Console.Write("Lüften bir metin giriniz: ");
string input = Console.ReadLine();
string output = "";
string[] strings = input.Split(" ");

foreach (var word in strings)
{
    char[] chars = word.ToCharArray();
    Array.Reverse(chars);
    string reverseWord = new string(chars);
    output += reverseWord + " "; 
}
Console.Write("Output: "+output);