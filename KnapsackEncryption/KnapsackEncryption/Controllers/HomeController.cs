using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_Gamma;

namespace KnapsackEncryption.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(/*string FilePath = ""*/)
        {
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

                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = file.FileName;
                    var file_path = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(file_path, FileMode.Create)){
                        await file.CopyToAsync(fileStream);
                    }


                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(10);
                    Response.Cookies.Append(Keys.FirstFilePathKey, file_path, options);

                    return RedirectToAction("Index", "Home");
                }
                else return NotFound("Error. There is no uploaded file");

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }


        public IActionResult DownloadFile(string FileName)
        {
            string FilePath = Request.Cookies[Keys.NewFilePathKey];

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

                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    var fileName = $"text_file_{DateTime.Now:yyyyMMddHHmmssfff}.txt";
                    var file_path = Path.Combine(uploadsFolder, fileName);

                    System.IO.File.WriteAllText(file_path, text);


                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddMinutes(10);
                    Response.Cookies.Append(Keys.FirstFilePathKey, file_path, options);

                    return RedirectToAction("Index", "Home");
                }
                else return NotFound("Error. Empty text provided.");

            }
            catch (Exception ex){
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Encryption()
        {
            ViewBag.FilePath = Request.Cookies[Keys.FirstFilePathKey];
            return View("Encryption");
        }
    }
}
