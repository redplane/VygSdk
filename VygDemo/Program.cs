using System;
using System.IO;
using System.Threading;
using VgySdk.Service;

namespace VygDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var vygService = new VgyService();
            vygService.SetUserKey("VfGUXhsDlPzRIF9akYOtcIynTzbEzfCn");
            
            // Find the file.
            var fullPath = @"D:\Wallpaper\Natural\italian_hills_landscape-wallpaper-1920x1080.jpg";
            var fileName = Path.GetFileName(fullPath);

            var bytes = File.ReadAllBytes(fullPath);
            vygService.UploadAsync(bytes, "image/png", fileName, CancellationToken.None).Wait();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
