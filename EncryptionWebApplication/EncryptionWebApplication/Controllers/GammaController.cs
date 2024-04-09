using EncryptionWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionWebApplication.Controllers
{
    public class GammaController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public GammaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public static Dictionary<char, int> frequencyTable;

        GammaEncryptionService gammaEncryptionService = new GammaEncryptionService();


        public IActionResult Index(string FilePath)
        {
            ViewBag.FilePath = FilePath;
            ViewBag.Content = FileService.ReadTextFromFileFile(FilePath);
            ViewBag.EncriptionType = "Gamma";

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





        public IActionResult Encrypt(string FilePath, string KEY)
        {
            string _key = KEY.ToUpper();
            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            string _EncryptedContent = gammaEncryptionService.Encrypt(sourceText, _key);
            Console.WriteLine(_EncryptedContent);
            /*if (_EncryptedContent is null)
            {
                RedirectToAction();
            }*/
            ViewBag.EncryptedContent = _EncryptedContent;
            //ViewBag.EncryptedContent = "_EncryptedContent";
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            ViewBag.EncriptionType = "Gamma";
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
        public IActionResult Decrypt(string FilePath, string gammaText)
        {

            string sourceText = FileService.ReadTextFromFileFile(FilePath);
            string _DecryptedContent = gammaEncryptionService.Decrypt(sourceText, "CA");
            /*if (_DecryptedContent is null)
            {
                RedirectToAction();
            }*/
            ViewBag.DecryptedContent = _DecryptedContent;
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            ViewBag.EncriptionType = "Gamma";
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

            string? resul = gammaEncryptionService.Attack();

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
