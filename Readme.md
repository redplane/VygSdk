# VGY SDK

### Description:
- Provide a sdk contains functions to help developers to upload images to [VGY Image Hosting](https://vgy.me/)

### APIs List:
- `UploadAsync<T>(bytes, contentType, fileName, cancellationToken)`: Upload image bytes array to [hosting](vgy.me).

- `SetUserKey(userKey)`: Set user key to http request to upload to a specific folder. By default, user key is empty, which means every image upload request will be treated as anonymous request.

For more detail information about APIs, you can refer to [VGY API document](https://vgy.me/api)

### Example code
    static void Main(string[] args)
    {
        var vygService = new VgyService();
        vygService.SetUserKey("<your-user-key>");
        
        // Find the file.
        var fullPath = @"D:\Wallpaper\Natural\italian_hills_landscape-wallpaper-1920x1080.jpg";
        var fileName = Path.GetFileName(fullPath);

        var bytes = File.ReadAllBytes(fullPath);
        var vgyResponse = vygService.UploadAsync<VgyResponseBase>(bytes, "image/png", fileName, CancellationToken.None).Result;
        Console.WriteLine("Done");
        Console.ReadLine();
    }

###  Issues report
- Any issue report, please create it on github, please.
- Any code update, please make CR.
