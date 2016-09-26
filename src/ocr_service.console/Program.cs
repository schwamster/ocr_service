using System;

namespace ocr_service.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var subscriptionKey = "no key";
            var path = @"no file";
            if (args.Length == 4)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-s")
                    {
                        subscriptionKey = args[i + 1];
                    }

                    if (args[i] == "-p")
                    {
                        path = args[i + 1];
                    }
                }
            }
            else
            {
                Console.WriteLine("usage: ocr_service -s <subscriptionkey> -p <pathToImage>");
                Environment.Exit(-1);
            }

            Console.WriteLine($"uploading Image '{path}' with you subsciption {subscriptionKey.Substring(0, 5)}...");

            var service = new OcrService();

            var result = service.ExtractTextFromFile(subscriptionKey, path);

            Console.WriteLine(result.Result);
        }
    }
}
