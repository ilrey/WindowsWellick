using System.Drawing;
using static WindowsWellick.SteganographyHelper;

namespace WindowsWellick
{
    public class Core
    {
        public static void Main()
        {
            string exeAssemblyLocation = Directory.GetCurrentDirectory();
            string imageFilePath = Path.Combine(exeAssemblyLocation, "static", "img", "wellick.png");
            Bitmap loadedImage = LoadImage(imageFilePath);
            string extractedCode = ExtractText(loadedImage);
        }
    }
}