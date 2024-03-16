using Microsoft.AspNetCore.Mvc;
using Hackaton_g12.Models;
using Hackathon_g12.Domain.Interfaces.Services;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hackaton_g12.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7260/");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadList(List<IFormFile> files)
    {
        try
        {

            using var content = new MultipartFormDataContent();

            foreach (var file in files)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "files",
                    FileName = file.FileName
                };

                content.Add(fileContent);
            }

            var response = await _httpClient.PostAsync("/api/video/upload", content);

            if (response.IsSuccessStatusCode)
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
            else
            {
                throw new Exception("Error");
            }

            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the upload: {ex.Message}");
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

