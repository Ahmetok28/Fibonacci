using Voting;

IVotingService votingService = new VotingService();
votingService.AddUser("Ahmet");
votingService.AddUser("Patika");
votingService.AddCategory("Film ");
votingService.AddCategory("Tech ");
votingService.AddCategory("Spor ");

while (true)
{
    Console.WriteLine("\n1- Kategori ekle");
    Console.WriteLine("2- Kullanıcı ekle");
    Console.WriteLine("3- Oy kullan");
    Console.WriteLine("4- Sonuçları görüntüle");
    Console.WriteLine("5- Çıkış yap");
    Console.Write("Seçiminiz: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Kategori adı: ");
        string categoryName = Console.ReadLine();

        if (votingService.AddCategory(categoryName))
        {
            Console.WriteLine($"\"{categoryName}\" kategorisi başarıyla eklendi.");
        }
        else
        {
            Console.WriteLine($"\"{categoryName}\" kategorisi zaten mevcut.");
        }
    }
    else if (choice == "2")
    {
        Console.Write("Kullanıcı adı: ");
        string userName = Console.ReadLine();

        if (votingService.AddUser(userName))
        {
            Console.WriteLine($"\"{userName}\" kullanıcısı başarıyla eklendi.");
        }
        else
        {
            Console.WriteLine($"\"{userName}\" kullanıcısı zaten mevcut.");
        }
    }
    else if (choice == "3")
    {
        Console.Write("Kullanıcı adı: ");
        string userName = Console.ReadLine();

        IUser user = votingService.GetUser(userName);

        if (user == null)
        {
            Console.WriteLine($"\"{userName}\" kayıt olmak ister misiniz?");
            Console.WriteLine("(E) Evet \n(H) Hayır");
            string answer = Console.ReadLine();

            if (answer.ToUpper()=="E")
            {
                if (votingService.AddUser(userName))
                {

                    Console.WriteLine($"\"{userName}\" kullanıcısı başarıyla eklendi.");
                    user = votingService.GetUser(userName);
                }
                else
                {
                    Console.WriteLine($"\"{userName}\" kullanıcısı kayıt olamadı.");
                }
            }
            else
            {
                continue;
            }
            
        }

        if (!votingService.CanUserVote(user))
        {
            Console.WriteLine($"\"{userName}\" kullanıcısı daha önce oy kullanmış.");
            continue;
        }

        Console.WriteLine("Mevcut kategoriler:");
        int sayac = 1;
        foreach (IVotingCategory cat in votingService.Categories)
        {
            Console.WriteLine($"{sayac}- {cat.Name}");
            sayac++;
        }

        Console.Write("Oy vermek istediğiniz kategorinin numarası: ");
        string categoryNumberStr = Console.ReadLine();
        if (!int.TryParse(categoryNumberStr, out int categoryNumber) || categoryNumber < 1 || categoryNumber > votingService.Categories.Count)
        {
            Console.WriteLine("Geçersiz kategori numarası.");
            continue;
        }

        IVotingCategory category = votingService.Categories[categoryNumber - 1];

        if (votingService.Vote(user, category))
        {
            Console.WriteLine($"\"{userName}\" kullanıcısı \"{category.Name}\" kategorisine oy verdi.");
        }
        else
        {
            Console.WriteLine($"\"{userName}\" kullanıcısı \"{category.Name}\" kategorisine oy veremez.");
        }
    }
    else if (choice == "4")
    {
        votingService.ShowResults();
    }
    else if (choice == "5")
    {
        Console.WriteLine("Çıkış yapılıyor...");
        break;
    }
    else
    {
        Console.WriteLine("Geçersiz seçim.");
    }
}