namespace BarcodeGeneratorAndReader
{
    public interface IBarcodeService
    {
        void ReadBarcode(string text);
        void WriteBarcode(string text);
    }
}