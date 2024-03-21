using EncryptionWebApplication.Models;
using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult Encryption(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            return View("Encryption");
        }
    }
}
