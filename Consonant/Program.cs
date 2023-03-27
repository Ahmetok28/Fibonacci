Console.Write("Lüften bir metin giriniz: ");
string input = Console.ReadLine();

string[] words = input.Split(" ");

foreach (var word in words)
{
    
    Console.Write(CheckConsonants(word)+" ");
}



static bool CheckConsonants(string input)
{
    string consonants = "bcdfghjklmnpqrstvwxyz";
    for (int i = 0; i < input.Length - 1; i++)
    {
        if (consonants.Contains(input[i]) && consonants.Contains(input[i + 1]))
        {
            return true;
        }
    }
    return false;
}