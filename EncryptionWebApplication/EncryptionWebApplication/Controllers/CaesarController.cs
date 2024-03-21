using DocumentFormat.OpenXml.Office.CustomUI;
using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionWebApplication.Controllers
{
    public class CaesarController : Controller
    {
        public static Dictionary<char, int> frequencyTable;

        CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();


        public IActionResult Index(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            ViewBag.Content = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.EncriptionType = "Caesar";

            return View("Index");
        }

        public IActionResult SettingPreEncrypt(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            ViewBag.Content = FileService.ReadTextFromFileFile(FilePath);
       

            return View("SettingPreEncrypt");
        }
        public IActionResult SettingPreDecrypt(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            ViewBag.Content = FileService.ReadTextFromFileFile(FilePath);
            

            return View("SettingPreDecrypt");
        }


        public IActionResult Encrypt(string FilePath, int step)
        {
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.EncryptedContent = caesarEncryptionService.Encrypt(sourceText, step);
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            
            
            ViewBag.EncriptionType = "Caesar";
            ViewBag.FileName = "encryptedfile.txt";

            var DecryptFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "EncryptFolder");

            if (!Directory.Exists(DecryptFolder))
                Directory.CreateDirectory(DecryptFolder);

            var uniqueFileName = ViewBag.FileName;
            var file_path = Path.Combine(DecryptFolder, uniqueFileName);
            ViewBag.NewFilePath = file_path;
            System.IO.File.WriteAllText(file_path, ViewBag.EncryptedContent);



            return View("Encrypt");
        }
        public IActionResult Decrypt(string FilePath, int step)
        {

            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.DecryptedContent = caesarEncryptionService.Decrypt(sourceText, step);
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            ViewBag.EncriptionType = "Caesar";
            ViewBag.FileName = "decryptedfile.txt";

            var DecryptFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "DecryptFolder");

            if (!Directory.Exists(DecryptFolder))
                Directory.CreateDirectory(DecryptFolder);
            
            var uniqueFileName = ViewBag.FileName;
            var file_path = Path.Combine(DecryptFolder, uniqueFileName);
            ViewBag.NewFilePath = file_path;
            System.IO.File.WriteAllText(file_path, ViewBag.DecryptedContent);
    
            return View("Decrypt");
        }

        public IActionResult Atack(string FilePath, string NewFilePath)
        {
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            string encryptedText = FileService.ReadTextFromFileFile(NewFilePath);

            string? resul = caesarEncryptionService.Attack(sourceText, encryptedText);

            if (resul == null) return Content("null");
            else return Content(resul);
        }



        public IActionResult PrintFrequencyTable()
        {
            ViewBag.Encounters = frequencyTable;
            return View("PrintFrequencyTable");

        }
    }
}
