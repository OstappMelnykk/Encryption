using DocumentFormat.OpenXml.Drawing;
using System.Text;
using WebApplication_Gamma_2;

namespace EncryptionWebApplication.Services
{
    public class GammaEncryptionService 
    {
        public string Decrypt(string sourceText, string GammaText)
        {
            string result = "";
            for (int i = 0; i < sourceText.Length; i++)
                result += DecryptChar(sourceText[i], GammaText[i]).ToString();

            return result;
        }

        public string Encrypt(string sourceText, string GammaText)
        {
            string result = "";

            for (int i = 0; i < sourceText.Length; i++)
                result += EncryptChar(sourceText[i], GammaText[i]).ToString();

            return result;
        }



        private static char DecryptChar(char toDecrypt, char fromGamma)
        {
            string _toDecrypt = GammaDictionary.Dict[toDecrypt];
            string _fromGamma = GammaDictionary.Dict[fromGamma];

            string resultBinaryString = XORBinaryStrings(_toDecrypt, _fromGamma);

            return GammaDictionary.ReversedDict[resultBinaryString];
        }

        private static char EncryptChar(char toEncrypt, char fromGamma)
        {
            string _toDecrypt = GammaDictionary.Dict[toEncrypt];
            string _fromGamma = GammaDictionary.Dict[fromGamma];


            string resultBinaryString = XORBinaryStrings(_toDecrypt, _fromGamma);
            Console.WriteLine(resultBinaryString + " --- " + GammaDictionary.ReversedDict[resultBinaryString]);
            return GammaDictionary.ReversedDict[resultBinaryString];
        }


        static string XORBinaryStrings(string binary1, string binary2)
        {
            if (binary1.Length != binary2.Length)
            {
                throw new ArgumentException("Lengths of binary strings are not equal.");
            }

            char[] result = new char[binary1.Length];

            for (int i = 0; i < binary1.Length; i++)
            {
                if (binary1[i] == binary2[i])
                {
                    result[i] = '0';
                }
                else
                {
                    result[i] = '1';
                }
            }

            return new string(result);
        }
    }
}
