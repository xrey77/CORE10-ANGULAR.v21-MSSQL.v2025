using Microsoft.AspNetCore.Mvc;

namespace core9_mysql.Controllers;

public class HomeController : Controller
{

    [HttpGet("/")]
    public async Task<IActionResult> GetHtmlFromFile()
    {

        var path = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
        var html = await System.IO.File.ReadAllTextAsync(path);
        return Content(html, "text/html");
        
    
    }
}