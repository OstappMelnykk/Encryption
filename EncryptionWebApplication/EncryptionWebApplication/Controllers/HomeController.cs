using EncryptionWebApplication.Models;
using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RawPrint;
using System.Drawing.Printing;
using System.Drawing;


namespace EncryptionWebApplication.Controllers
{
    public class HomeController : Controller
    {       
        public IActionResult Index(string FilePath = "")
        {
            ViewBag.FilePath = FilePath;
            return View("Index");
        }

        public IActionResult DevInfo()
        {
            return View("DevInfo");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var uploadsFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "Files");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = file.FileName;
                    var file_path = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(file_path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    return RedirectToAction("Index", "Home", new { FilePath = file_path });
                }
                else return NotFound("Error. There is no uploaded file");

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }


        public IActionResult DownloadFile(string FilePath, string FileName)
        {
            return PhysicalFile(FilePath, "application/octet-stream", FileName);
        }

        public IActionResult PrintFile(string FilePath)
        {
            string filePath = FilePath;
            return StatusCode(200);
        }


        [HttpGet]
        public IActionResult CreateFile()
        {
            return View("CreateFile");
        }


        [HttpPost]
        public IActionResult CreateFile(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var uploadsFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "Files");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = $"text_file_{DateTime.Now:yyyyMMddHHmmssfff}.txt"; // Генеруємо унікальне ім'я файлу
                    var file_path = Path.Combine(uploadsFolder, fileName);

                    // Записуємо текст у файл
                    System.IO.File.WriteAllText(file_path, text);

                    return RedirectToAction("Index", "Home", new { FilePath = file_path });
                }
                else
                {
                    return NotFound("Error. Empty text provided.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Encryption(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            return View("Encryption");
        }
    }
}
