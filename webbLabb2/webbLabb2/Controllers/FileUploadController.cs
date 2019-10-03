using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;


public class FileUploadController : Controller
{
    [HttpPost("FileUpload")]
    public async Task<IActionResult> Index(IFormFile file)
    {
        // full path to file in temp location
        var filePath = "wwwroot/json/";

        using (var stream = new FileStream(filePath + file.FileName, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Don't rely on or trust the FileName property without validation.

        return Redirect("/Home");
    }
}