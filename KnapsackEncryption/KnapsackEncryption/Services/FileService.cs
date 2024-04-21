using DocumentFormat.OpenXml.Packaging;

namespace EncryptionWebApplication.Services
{
    public static class FileService
    {
        public static string ReadTextFromFileFile(string filePath)
        {
            if (System.IO.File.Exists(filePath) && Path.GetExtension(filePath)?.ToLower() == ".txt")
            {
                var content = System.IO.File.ReadAllText(filePath);
                return content;
            }
            else if (System.IO.File.Exists(filePath) && Path.GetExtension(filePath)?.ToLower() == ".docx")
            {
                string text = string.Empty;
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                {
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    if (mainPart != null)
                        text = mainPart.Document.Body.InnerText;
                }

                return text;
            }
            else
            {
                throw new ArgumentException("Invalid file path or file type.");
            }

        }
    }
}
