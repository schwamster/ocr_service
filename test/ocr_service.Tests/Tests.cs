using System;
using Xunit;
using System.IO;
using System.Reflection;

namespace ocr_service.Tests
{
    public class OcrServiceTest
    {
        private readonly OcrService _service;

        private string GetPath(string relativePath){
            var location = typeof(OcrServiceTest).GetTypeInfo().Assembly.Location;
            var dirPath = Path.GetDirectoryName(location);
            return Path.Combine(dirPath, relativePath);
        }

        public OcrServiceTest()
        {
            var subscriptionKey = "getakeyfor_computer_vision_cognitiveservices";
            _service = new OcrService(subscriptionKey);
        }

        [Fact(Skip ="usage test")]
        public void ExtractTextFromFileTest()
        {
            var path = @"C:\tmp\ocr-test.png";

            string result = _service.ExtractTextFromFile(path).Result;

        }

        [Fact]
        public void ParseResultTest_GivenAValidJsonResult_ReturnsOcrResult() 
        {
            var json = File.ReadAllText(GetPath("testdata/example-ocr-result.json"));
            var result = _service.ParseResult(json);

            Assert.NotNull(result);
        }
    }
}
