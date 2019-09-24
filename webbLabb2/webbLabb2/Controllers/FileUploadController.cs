using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;


public class FileUploadController : Controller
{
    private readonly IHostingEnvironment _hostingEnvironment;
    public FileUploadController(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost("FileUpload")]
    public async Task<IActionResult> Index(List<IFormFile> files)
    {
        long size = files.Sum(f => f.Length);

        var filePaths = new List<string>();
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                string name = formFile.FileName;
                // full path to file in temp location
                var filePath = Path.GetTempFileName();
                filePaths.Add(filePath);

                string projectRootPath = _hostingEnvironment.WebRootPath;

                using (var stream = new FileStream("~images/" + name, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }

        // process uploaded files
        // Don't rely on or trust the FileName property without validation.

        return Ok(new { count = files.Count, size, filePaths });
    }
}