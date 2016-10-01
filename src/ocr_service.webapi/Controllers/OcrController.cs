using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ocr_service.webapi.Controllers
{
    [Route("api/[controller]")]
    public class OcrController : Controller
    {
        private readonly IConfiguration config;
        private IOcrService ocrService;
        private IHostingEnvironment environment;
        private readonly ILogger<OcrController> logger;

        public OcrController(IOcrService ocrService, IConfiguration config, IHostingEnvironment environment, ILogger<OcrController> logger)
        {
            this.ocrService = ocrService;
            this.config = config;
            this.environment = environment;
            this.logger = logger;
        }

        // GET api/ocr
        [HttpGet]
        public string Get()
        {
            return "Post an image to api/ocr to extract text from that image";
        }

        [HttpPost]
        public async Task<string> Index(ICollection<IFormFile> files)
        {
            var result = "no result";
            var uploads = Path.Combine(environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    result = await this.ocrService.ExtractTextFromFile(Path.Combine(uploads, file.FileName));
                }
            }
            return result;
        }
    }
}
