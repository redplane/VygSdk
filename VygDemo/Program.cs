using System;
using System.IO;
using System.Threading;
using VgySdk.Models;
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
            var vgyResponse = vygService.UploadAsync<VgyResponseBase>(bytes, "image/png", fileName, CancellationToken.None).Result;
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
