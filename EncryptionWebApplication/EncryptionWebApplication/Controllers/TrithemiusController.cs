
using EncryptionWebApplication.Services;
using EncryptionWebApplication.Services.TrithemiusEncryptionServices;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionWebApplication.Controllers
{
    public class TrithemiusController : Controller
    {
        private static BaseTrithemiusEncryptionService _encryptor;

        public IActionResult Index(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            ViewBag.Content = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.EncriptionType = "Trithemius";

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



        public IActionResult EncryptLinear(string FilePath, int A, int B)
        {
            _encryptor = new TrithemiusLinearEncryptionService(A, B);
            return RedirectToAction("Encrypt", "Trithemius", new { FilePath = FilePath });
        }

        public IActionResult EncryptNonLinear(string FilePath, int A, int B, int C)
        {
            _encryptor = new TrithemiusNonLinearEncryptionService(A, B, C);
            return RedirectToAction("Encrypt", "Trithemius", new { FilePath = FilePath });
        }
        public IActionResult EncryptWatchword(string FilePath, string Watchword)
        {
            _encryptor = new TrithemiusWatchwordEncryptionService(Watchword);
            return RedirectToAction("Encrypt", "Trithemius", new { FilePath = FilePath });
        }



        public IActionResult DecryptLinear(string FilePath, int A, int B)
        {
            _encryptor = new TrithemiusLinearEncryptionService(A, B);
            return RedirectToAction("Decrypt", "Trithemius", new { FilePath = FilePath });
        }
        public IActionResult DecryptNonLinear(string FilePath, int A, int B, int C)
        {
            _encryptor = new TrithemiusNonLinearEncryptionService(A, B, C);


            return RedirectToAction("Decrypt", "Trithemius", new { FilePath = FilePath });
        }

        public IActionResult DecryptWatchword(string FilePath, string Watchword) 
        {
            _encryptor = new TrithemiusWatchwordEncryptionService(Watchword);
            return RedirectToAction("Decrypt", "Trithemius", new { FilePath = FilePath });
        }

        
        public IActionResult Encrypt(string FilePath)
        {
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.EncryptedContent = _encryptor.Encrypt(sourceText);
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;


            ViewBag.EncriptionType = "Trithemius";
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
        public IActionResult Decrypt(string FilePath)
        {
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.DecryptedContent = _encryptor.Decrypt(sourceText);
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            ViewBag.EncriptionType = "Trithemius";
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







        public IActionResult AtackLinear(string FilePath, string NewFilePath)
        {
            _encryptor = new TrithemiusLinearEncryptionService();

            return RedirectToAction("Atack", "Trithemius", new { FilePath = FilePath, NewFilePath = NewFilePath });
        }

        public IActionResult AtackNonLinear(string FilePath, string NewFilePath)
        {
            _encryptor = new TrithemiusNonLinearEncryptionService();

            return RedirectToAction("Atack", "Trithemius", new { FilePath = FilePath, NewFilePath = NewFilePath });
        }
        public IActionResult AtackWatchword (string FilePath, string NewFilePath)
        {
            _encryptor = new TrithemiusWatchwordEncryptionService();

            return RedirectToAction("Atack", "Trithemius", new { FilePath = FilePath, NewFilePath = NewFilePath });
        }





        public IActionResult Atack(string FilePath, string NewFilePath)
        {
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            string encryptedText = FileService.ReadTextFromFileFile(NewFilePath);

            string? resul = _encryptor.Attack(sourceText, encryptedText);

            if (resul == null) return Content("null");
            else return Content(resul);
        }



        public IActionResult PrintFrequencyTable()
        {
            ViewBag.Encounters = _encryptor.frequencyTable;
            return View("PrintFrequencyTable");

        }
    }
}
