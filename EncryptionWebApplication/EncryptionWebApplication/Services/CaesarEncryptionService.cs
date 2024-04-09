using EncryptionWebApplication.Controllers;
using System.Text;

namespace EncryptionWebApplication.Services
{
    public class CaesarEncryptionService : ICoder
    {
        public string Encrypt(string sourceText, int step)
        {
            CaesarController.frequencyTable = new();

            var encryptedText = new string(sourceText.Select(v => EncodeChar(v, step)).ToArray());
            return encryptedText;
        }

        public string Decrypt(string sourceText, int step)
        {
            var decryptedText = new string(sourceText.Select(v => DecodeChar(v, step)).ToArray());
            return decryptedText;
        }

        public string? Attack(string sourceText, string encryptedText)
        {
            int step = 0;
            string text = "";

            while (step < 10000)
            {
                if (new string(encryptedText.Select(v => DecodeChar(v, step)).ToArray()) == sourceText)
                    return text; //return step.ToString();

                step++;
                text += new string(encryptedText.Select(v => DecodeChar(v, step)).ToArray()) + "\n\n";
            }
            if (step == 1000)
                return "The brute force attack failed";

            return null;
        }


        private char EncodeChar(char from, int step)
        {
            if (Alphabets.ukrainian.Contains(from)){
                var current = Alphabets.ukrainian.IndexOf(from);

                if (CaesarController.frequencyTable.ContainsKey(Alphabets.ukrainianCapital[current]))
                    CaesarController.frequencyTable[Alphabets.ukrainianCapital[current]]++;
                else
                    CaesarController.frequencyTable[Alphabets.ukrainianCapital[current]] = 1;

                int index = (current + step) % Alphabets.ukrainianLen;
                if (index < 0) index += Alphabets.ukrainianLen;
                return Alphabets.ukrainian[index];
            }

            if (Alphabets.ukrainianCapital.Contains(from)){
                var current = Alphabets.ukrainianCapital.IndexOf(from);

                if (CaesarController.frequencyTable.ContainsKey(from)) 
                    CaesarController.frequencyTable[from]++;
                else 
                    CaesarController.frequencyTable[from] = 1;

                int index = (current + step) % Alphabets.ukrainianLen;
                if (index < 0) index += Alphabets.ukrainianLen;
                return Alphabets.ukrainianCapital[index];
            }

            if (from > 64 && from < 91){
                int current = from - 'A';

                if (CaesarController.frequencyTable.ContainsKey(from))
                    CaesarController.frequencyTable[from]++;
                else
                    CaesarController.frequencyTable[from] = 1;

                int index = (current + step) % Alphabets.englishLen;
                if (index < 0) index += Alphabets.englishLen;
                return (char)(index + 'A');
            }

            if (from > 96 && from < 123){
                int current = from - 'a';

                if (CaesarController.frequencyTable.ContainsKey((char)(current + 'A')))
                    CaesarController.frequencyTable[(char)(current + 'A')]++;
                else
                    CaesarController.frequencyTable[(char)(current + 'A')] = 1;

                int index = (current + step) % Alphabets.englishLen;
                if (index < 0) index += Alphabets.englishLen;
                return (char)(index + 'a');
            }

            return from;
        }

        private static char DecodeChar(char from, int step)
        {
            if (Alphabets.ukrainian.Contains(from)){
                var current = Alphabets.ukrainian.IndexOf(from);
                int index = (current - step) % Alphabets.ukrainianLen;
                if (index < 0) index += Alphabets.ukrainianLen;
                return Alphabets.ukrainian[index];
            }

            if (Alphabets.ukrainianCapital.Contains(from)){
                var current = Alphabets.ukrainianCapital.IndexOf(from);
                int index = (current - step) % Alphabets.ukrainianLen;
                if (index < 0) index += Alphabets.ukrainianLen;
                return Alphabets.ukrainianCapital[index];
            }

            if (from > 64 && from < 91){
                int current = from - 'A';
                int index = (current - step) % Alphabets.englishLen;
                if (index < 0) index += Alphabets.englishLen;
                return (char)(index + 'A');
            }

            if (from > 96 && from < 123){
                int current = from - 'a';
                int index = (current - step) % Alphabets.englishLen;
                if (index < 0) index += Alphabets.englishLen;
                return (char)(index + 'a');
            }
            return from;
        }
    }
}
