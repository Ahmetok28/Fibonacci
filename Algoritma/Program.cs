

    Console.Write("String ve index değerini virgülle ayırarak giriniz ");
    string input = Console.ReadLine();

    string[] inputArray = input.Split(',');
    string str = inputArray[0].Trim();
    int index;
    bool success = int.TryParse(inputArray[1].Trim(), out index);

    if (success && index >= 0 && index < str.Length)
    {
        Console.WriteLine("Sonuç: " + str.Remove(index, 1));
    }
    else
    {
        Console.WriteLine("Hatalı girdi, tekrar deneyiniz.");
    }
