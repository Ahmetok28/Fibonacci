int[,] numbers = GetNumbersFromUser();
int[] results = new int[numbers.GetLength(0)];

for (int i = 0; i < numbers.GetLength(0); i++)
{
    results[i] = Sum(numbers[i, 0] , numbers[i, 1]);
}

// Sonuçları ekrana yazdırma
foreach (int result in results)
{
    Console.Write(result + " ");
}


int[,] GetNumbersFromUser()
{
    Console.WriteLine("Lütfen bir veya daha fazla integer ikili girin:");
    string input = Console.ReadLine();

    string[] values = input.Split(' ');
    int[,] numbers = new int[values.Length / 2, 2]; // 2xN boyutunda bir dizi oluşturur

    for (int i = 0; i < values.Length; i += 2) // ayırılan verileri sırayla alır
    {
        int x = int.Parse(values[i]);
        int y = int.Parse(values[i + 1]);
        numbers[i / 2, 0] = x; // X koordinatını diziye kaydeder
        numbers[i / 2, 1] = y; // Y koordinatını diziye kaydeder
    }
    return numbers;
}

int Sum(int a, int b)
{
    if (a == b) return (a+b)*(a+b);
    return a + b;
}
