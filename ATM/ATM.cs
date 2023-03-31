using System;
using System.Collections.Generic;
using System.IO;

namespace ATM
{


    public class ATM
    {
        private List<User> users = new List<User>();
        private User currentUser;
        private string transactionLog = "transaction_log.txt";

        public void Run()
        {
            Console.WriteLine("ATM'ye Hoş Geldiniz!");

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1 - Giriş yap");
                Console.WriteLine("2 - Kaydol");
                Console.WriteLine("3 - Çıkış yap");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }

        private void Login()
        {
            Console.Write("Kullanıcı adı: ");
            string username = Console.ReadLine();

            Console.Write("PIN: ");
            string pin = Console.ReadLine();

            // Girilen kullanıcı adı ve PIN ile eşleşen kullanıcıyı bulun
            User user = users.Find(u => u.Name == username && u.PIN == pin);

            if (user == null)
            {
                Console.WriteLine("Geçersiz kullanıcı adı veya PIN.");
                return;
            }

            currentUser = user;
            Console.WriteLine($"Hoş geldin, {currentUser.Name}!");

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1 - Para yatır");
                Console.WriteLine("2 - Para çek");
                Console.WriteLine("3 - Ödeme yap");
                Console.WriteLine("4 - Gün sonu");
                Console.WriteLine("5 - Çıkış yap");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Deposit();
                        break;
                    case "2":
                        Withdraw();
                        break;
                    case "3":
                        Pay();
                        break;
                    case "4":
                        EndOfDay();
                        break;
                    case "5":
                        Logout();
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }
        private void Deposit()
        {
            Console.Write("Yatırmak istediğiniz tutar: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Lütfen geçerli bir tutar girin.");
                return;
            }

            currentUser.Balance += amount;
            LogTransaction($"Para yatırma: {amount:C}");
            Console.WriteLine($"Yeni bakiyeniz: {currentUser.Balance:C}");
        }

        private void Withdraw()
        {
            Console.Write("Çekmek istediğiniz tutar: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Lütfen geçerli bir tutar girin.");
                return;
            }

            if (amount > currentUser.Balance)
            {
                Console.WriteLine("Yetersiz bakiye.");
                return;
            }

            currentUser.Balance -= amount;
            LogTransaction($"Para çekme: {amount:C}");
            Console.WriteLine($"Yeni bakiyeniz: {currentUser.Balance:C}");
        }

        private void Pay()
        {
            Console.Write("Ödeme yapmak istediğiniz tutar: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Lütfen geçerli bir tutar girin.");
                return;
            }

            if (amount > currentUser.Balance)
            {
                Console.WriteLine("Yetersiz bakiye.");
                return;
            }

            Console.Write("Ödeme alıcısı: ");
            string recipient = Console.ReadLine();

            currentUser.Balance -= amount;
            LogTransaction($"Ödeme: {amount:C} - Alıcı: {recipient}");
            Console.WriteLine($"Yeni bakiyeniz: {currentUser.Balance:C}");
        }

        private void LogTransaction(string message)
        {
            using (StreamWriter sw = File.AppendText(transactionLog))
            {
                sw.WriteLine($"{DateTime.Now} - {message}");
            }
        }

        private void Register()
        {
            Console.Write("Kullanıcı adı: ");
            string username = Console.ReadLine();

            Console.Write("PIN: ");
            string pin = Console.ReadLine();

            if (users.Find(u => u.Name == username) != null)
            {
                Console.WriteLine("Bu kullanıcı adı zaten alınmış.");
                return;
            }

            users.Add(new User { Name = username, PIN = pin, Balance = 0 });
            Console.WriteLine("Kayıt başarılı.");
        }
        private void Logout()
        {
            currentUser = null;
            Console.WriteLine("Başarıyla çıkış yaptınız.");
        }

        private void EndOfDay()
        {
            string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Transaction Logs:");

                if (File.Exists(transactionLog))
                {
                    string[] logs = File.ReadAllLines(transactionLog);
                    foreach (string log in logs)
                    {
                        sw.WriteLine(log);
                    }

                    //File.Delete(transactionLog);
                }
                else
                {
                    sw.WriteLine("There are no transactions today.");
                }

                sw.WriteLine();

                sw.WriteLine("Invalid Login Attempts:");

                foreach (User user in users)
                {
                    if (user.Balance < 0)
                    {
                        sw.WriteLine($"Username: {user.Name}, Balance: {user.Balance}");
                    }
                }
            }

            Console.WriteLine($"Gün sonu işlemleri tamamlandı. {fileName} dosyasına loglar yazıldı.");
        }

        private void Exit()
        {
            Console.WriteLine("Çıkış yapılıyor.");
            Environment.Exit(0);
        }
    }
}