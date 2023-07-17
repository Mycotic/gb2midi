using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gb2midi.Models;
using System.Collections.Generic;

namespace gb2midi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                // full path to file in temp location
                //var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                //filePaths.Add(filePath);
                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    await formFile.CopyToAsync(stream);
                //}
                //Stream streamFile = formFile.OpenReadStream();
                //streamFile.
                StreamReader sr = new StreamReader(formFile.OpenReadStream());
                List<string> lines = new List<string>();
                lines.Add(sr.ReadLine());
                lines.Add(sr.ReadLine());
                lines.Add(sr.ReadLine());
                lines.Add(sr.ReadLine());
                return Ok(new { count = files.Count, size, filePaths, lines });
            }
        }
        // process uploaded files
        // Don't rely on or trust the FileName property without validation.
        return Ok(new { count = files.Count, size, filePaths });
    }
}

