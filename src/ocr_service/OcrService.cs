using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace ocr_service
{
    public interface IOcrService
    {
        System.Threading.Tasks.Task<string> ExtractTextFromFile(string path);
    }

    public class OcrService : IOcrService
    {
        public const string baseAdress = "https://api.projectoxford.ai/vision/v1.0/ocr?language=en";
        public const string subscriptionHeaderName = "ocp-apim-subscription-key";
        private string subscriptionKey; 
        public OcrService(string subscriptionKey)
        {
            this.subscriptionKey = subscriptionKey;
        }

        public async System.Threading.Tasks.Task<string> ExtractTextFromFile(string path)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart-form");
                client.DefaultRequestHeaders.TryAddWithoutValidation(subscriptionHeaderName, subscriptionKey);

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(new FileStream(path, FileMode.Open)), "file", "upload.png");

                    using (var message = await client.PostAsync(baseAdress, content))
                    {
                        var input = await message.Content.ReadAsStringAsync();

                        return input;
                    }
                }
            }
        }

        public OcrResult ParseResult(string json)
        {
            return new OcrResult();
        }


    }

    public class OcrResult
    {

    }
}

