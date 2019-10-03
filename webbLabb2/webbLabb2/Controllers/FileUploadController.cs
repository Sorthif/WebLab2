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
    public async Task<IActionResult> Index(IFormFile jsonFile, IFormFileCollection imageFiles)
    {
        // full path to file in temp location
        var filePath = "wwwroot/json/";

        using (var stream = new FileStream(filePath + jsonFile.FileName, FileMode.Create))
        {
            await jsonFile.CopyToAsync(stream);
        }

        filePath = "wwwroot/images/";
        foreach (var imageFile in imageFiles)
        {
            using (var stream = new FileStream(filePath + imageFile.FileName, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
        }

        // Don't rely on or trust the FileName property without validation.

        return Redirect("/Home");
    }
}