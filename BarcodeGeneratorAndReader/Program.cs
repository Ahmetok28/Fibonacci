using BarcodeGeneratorAndReader;

IBarcodeService barcodeService = new ZXingBarcode();

while (true)
{
    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz ");
    Console.WriteLine("1- Barkod Oluştur \n2- Barkod Oku\n3- Çıkış");
    string answer = Console.ReadLine();
	if (answer=="1")
	{
		Console.WriteLine("Barkodunu oluşturmak istediğiniz veriyi giriniz: ");
		string read=Console.ReadLine();
        barcodeService.WriteBarcode(read);
		continue;
	}
	else if (answer=="2")
	{
		Console.WriteLine("Okumak istedğiniz barkod resminin tam yolunu giriniz:");
        string read = Console.ReadLine();
        barcodeService.ReadBarcode(read);
		continue;
    }
	else if(answer=="3")
	{
		break;
	}
	else
	{
		Console.WriteLine("Hatalı Veri Girdiniz Lütfen Tekrar deneyiniz");
		continue;
	}

}