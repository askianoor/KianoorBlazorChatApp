using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KianoorBlazorApp.Server.Controllers
{
    [Route("Upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private string FILE_NAME;
        private readonly string FILE_PATH;
        private const string SUB_FOLDER = "upload/uploaded_imgs";

        public UploadController(IWebHostEnvironment environment)
        {
            FILE_PATH = Path.Combine(environment.ContentRootPath, "wwwroot", SUB_FOLDER);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            List<string> filePaths = new List<string>();
            if (HttpContext.Request.Form.Files.Any())
            {
                if (!Directory.Exists(FILE_PATH)) Directory.CreateDirectory(FILE_PATH);

                foreach (var file in HttpContext.Request.Form.Files)
                {
                    string pathStr = GetNewFileName();//file.FileName
                    using (var stream = new FileStream(pathStr, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    filePaths.Add(Path.Combine(SUB_FOLDER, FILE_NAME));
                }   
            }
            return Ok(filePaths);
        }

        private string GetNewFileName()
        {
            FILE_NAME = Path.GetRandomFileName().Split('.')[0] + ".jpg";
            string pathStr = Path.Combine(FILE_PATH, FILE_NAME);

            if (System.IO.File.Exists(pathStr))
            {
                return GetNewFileName();
            }
            return pathStr;
        }
    }
}