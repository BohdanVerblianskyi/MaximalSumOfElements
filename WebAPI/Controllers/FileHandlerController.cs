using MaximalSumOfElements;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FileHandlerController : Controller
{
    [HttpGet]
    public async Task<ActionResult<string>> Get(string fileName)
    {
        var combine = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        
        if (System.IO.File.Exists(combine) == false)
        {
            return NotFound("not found the file ");
        }
        
        var readingFile = FileHandler.ReadFile(fileName);
        
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(readingFile);

        return Ok(json);
    }
}