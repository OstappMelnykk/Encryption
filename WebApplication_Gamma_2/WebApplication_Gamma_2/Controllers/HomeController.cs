using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_Gamma;

namespace WebApplication_Gamma_2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        GammaEncryptionService gammaEncryptionService = new GammaEncryptionService();



        [HttpPost]
        public async Task<IActionResult> UploadFile__1(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "Files_1");

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


        [HttpPost]
        public async Task<IActionResult> UploadFile__2(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "Files_2");

                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);


                var uniqueFileName = file.FileName;
                var file_path = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(file_path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }


                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append(Keys.SecondFilePathKey, file_path, options);

                return RedirectToAction("Index", "Home");
            }
            else return NotFound("Error. There is no uploaded file");
        }


        public IActionResult Encrypt()
        {
            var sourceFile__1__Content = FileService.ReadTextFromFileFile(Request.Cookies[Keys.FirstFilePathKey]);
            var sourceFile__2__Content = FileService.ReadTextFromFileFile(Request.Cookies[Keys.SecondFilePathKey]);

            if (sourceFile__1__Content.Length != sourceFile__2__Content.Length)
            {
                throw new Exception();
            }

            string EncryptedText = gammaEncryptionService.Encrypt(sourceFile__1__Content, sourceFile__2__Content);


            return Content(EncryptedText);
        }


        public IActionResult Decrypt()
        {

            var sourceFile__1__Content = FileService.ReadTextFromFileFile(Request.Cookies[Keys.FirstFilePathKey]);
            var sourceFile__2__Content = FileService.ReadTextFromFileFile(Request.Cookies[Keys.SecondFilePathKey]);

            if (sourceFile__1__Content.Length != sourceFile__2__Content.Length)
            {
                throw new Exception();
            }


            string DecryptedText = gammaEncryptionService.Decrypt(sourceFile__1__Content, sourceFile__2__Content);

            return Content(DecryptedText);
        }
    }
}
