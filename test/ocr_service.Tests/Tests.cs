using System;
using Xunit;

namespace ocr_service.Tests
{
    public class OcrServiceTest
    {
        private readonly OcrService _service;

        public OcrServiceTest()
        {
             _service = new OcrService();
        }

        [Fact(Skip ="usage test")]
        public void ExtractTextFromFileTest()
        {
            var subscriptionKey = "getakeyfor_computer_vision_cognitiveservices";
            var path = @"C:\tmp\ocr-test.png";

            string result = _service.ExtractTextFromFile(subscriptionKey, path).Result;

        }

        [Fact]
        public void ParseResultTest_GivenAValidJsonResult_ReturnsOcrResult() 
        {
            var json = System.IO.File.ReadAllText("./testdata/example-ocr-result.json");
            var result = _service.ParseResult(json);

            Assert.NotNull(result);
        }
    }
}
