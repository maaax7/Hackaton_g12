using Microsoft.AspNetCore.Mvc;
using Hackaton_g12.Models;

namespace Hackaton_g12.Controllers;

public class HomeController : Controller
{
    private readonly List<UploadFile>? _files;
    
    public IActionResult Index()
    {
        return View(_files);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadList(List<IFormFile> files)
    {
        try
        {
            List<UploadFile> list = new List<UploadFile>();

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);
                string description = $"File: {fileName}";
                string status = "P"; 

                list.Add(new UploadFile { Description = description, Status = status, ProcessDate = DateTime.Now });
            }

            return View(list);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"n error occurred while processing the upload: {ex.Message}");
            return StatusCode(500, "An error occurred while processing the upload.");
        }
    }

    public async Task<IActionResult> Download(int id)
    {
        UploadFile? file = GetFileById(id);  //teste

        if (file == null)
        {
            return NotFound(); 
        }

        string? fileName = null;//file.FileName; 
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CaminhoParaOsArquivos", fileName!);

        var memory = new MemoryStream();
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;

        return File(memory, "application/octet-stream", Path.GetFileName(fileName));
    }

    private UploadFile? GetFileById(int id)
    {
        return null;
    }
}

