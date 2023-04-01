

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using ZXing;
using ZXing.Common;
using ZXing.OpenCV;
using ZXing.QrCode;
using static System.Net.Mime.MediaTypeNames;

namespace BarcodeGeneratorAndReader
{
    internal class ZXingBarcode : IBarcodeService
    {
        public void WriteBarcode(string text)
        {
            // Barcode formatı belirleme
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 0
                }
            };

            // Barcode'u oluşturma
            var pixelData = barcodeWriter.Write(text);

            // Bitmap oluşturma
            var bitmap = new Bitmap(pixelData.Width, pixelData.Height);
            var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Bitmap'e pixelData'yı yazma
            var bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            try
            {
                // Pixel verilerini kopyalama
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            // Oluşturulan barcode'u kaydetme
            string filePath = "C:\\Users\\Ahmet\\Desktop" + $"{text}.png";
            bitmap.Save(filePath);
            Console.WriteLine("******************************");
            Console.WriteLine();
            Console.WriteLine($"Barcode başarıyla oluşturuldu ve {filePath} adlı dosyaya kaydedildi.");
            Console.WriteLine();
            Console.WriteLine("******************************");
        }

        public void ReadBarcode(string filePath)
        {
            using (Bitmap bitmap = new Bitmap(filePath))
            {
                // Bitmap nesnesini bayt dizisine dönüştür
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Bmp);
                byte[] bytes = ms.ToArray();

                // Bayt dizisini Mat nesnesine dönüştür
                Mat mat = BitmapConverter.ToMat(new Bitmap(ms));

                // Barkodu oku
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode(mat);
                if (result != null)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine();
                    Console.WriteLine("Barkod metni: " + result.Text);
                    Console.WriteLine();
                    Console.WriteLine("******************************");
                }
                else
                    Console.WriteLine("Barkod okunamadı.");
            }
           
        }

       
    }


}
