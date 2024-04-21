using EncryptionWebApplication.Services;
using KnapsackEncryption.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication_Gamma;

namespace KnapsackEncryption.Controllers
{
    public class KnapsackController : Controller
    {
        
        KnapsackEncryptionService knapsackEncryptionService = new KnapsackEncryptionService();
        public IActionResult Index()
        {
            string filePath = Request.Cookies[Keys.FirstFilePathKey];
            ViewBag.Content = FileService.ReadTextFromFileFile(filePath);
            ViewBag.EncriptionType = "Knapsack";

            return View("Index");
        }




        public IActionResult SettingPreEncrypt()
        {

            string filePath = Request.Cookies[Keys.FirstFilePathKey];
            ViewBag.Content = FileService.ReadTextFromFileFile(filePath);

            return View("SettingPreEncrypt");
        }
        public IActionResult SettingPreDecrypt()
        {
            string filePath = Request.Cookies[Keys.FirstFilePathKey];
            ViewBag.Content = FileService.ReadTextFromFileFile(filePath);


            return View("SettingPreDecrypt");
        }









        public IActionResult Encrypt(string _W, int q, int r)
        {                                         
            string FilePath = Request.Cookies[Keys.FirstFilePathKey];


            string sourceText = FileService.ReadTextFromFileFile(FilePath);

            Random rand = new Random();
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine(_W);
            List<int> W = ConvertStringToList(_W);
            List<int> B = CalculateSequenceB(W, r, q);


            /*List<int> W = [2, 7, 11, 21, 42, 89, 180, 354];
            var q = 881;
            var r = 588;
            List<int> B = [295, 592, 301, 14, 28, 353, 120, 236];*/




            ViewBag.EncryptedContent = knapsackEncryptionService.Encrypt(sourceText, W, q, r, B);
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


            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append(Keys.NewFilePathKey, file_path, options);
            


            System.IO.File.WriteAllText(file_path, ViewBag.EncryptedContent);



            return View("Encrypt");
        }
        public IActionResult Decrypt(string _W, int q, int r)
        {
            string FilePath = Request.Cookies[Keys.FirstFilePathKey];

            string sourceText = FileService.ReadTextFromFileFile(FilePath);


            Console.WriteLine(_W);
            List<int> W = ConvertStringToList(_W);
            
            /*List<int> W = [2, 7, 11, 21, 42, 89, 180, 354];
            var q = 881;
            var r = 588;
            List<int> B = [295, 592, 301, 14, 28, 353, 120, 236];*/


            ViewBag.DecryptedContent = knapsackEncryptionService.Decrypt(sourceText, W, q, r);
            ViewBag.Content = sourceText;
            ViewBag.FilePath = FilePath;
            ViewBag.EncriptionType = "Caesar";
            ViewBag.FileName = "decryptedfile.txt";

            var DecryptFolder = Path.Combine("..", Directory.GetCurrentDirectory(), "DecryptFolder");

            if (!Directory.Exists(DecryptFolder)) Directory.CreateDirectory(DecryptFolder);

            var uniqueFileName = ViewBag.FileName;
            var file_path = Path.Combine(DecryptFolder, uniqueFileName);
            ViewBag.NewFilePath = file_path;


            
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append(Keys.NewFilePathKey, file_path, options);

            System.IO.File.WriteAllText(file_path, ViewBag.DecryptedContent);

            return View("Decrypt");
        }

        static List<int> ConvertStringToList(string input)
        {
            string[] numberStrings = input.Split(' ');
            List<int> numbers = new List<int>();

            foreach (string numberString in numberStrings)
            {
                if (!int.TryParse(numberString, out int number)) throw new FormatException();
                numbers.Add(number);
            }
            return numbers;
        }

        int GenerateCoprime(int q, Random rand)
        {
            int r;
            do
            {
                r = rand.Next(2, q); // Randomly generate r between 2 and q-1
            }
            while (GreatestCommonDivisor(r, q) != 1); // Repeat until r and q are coprime

            return r;
        }

        int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static List<int> CalculateSequenceB(List<int> W, int r, int q)
        {
            List<int> B = new List<int>();

            foreach (int wi in W)
            {
                int bi = (r * wi) % q;
                B.Add(bi);
            }

            return B;
        }
    }
}
