using DocumentFormat.OpenXml.Drawing;
using System.Text;

namespace EncryptionWebApplication.Services
{
    public class GammaEncryptionService 
    {
        public string? Attack()
        {
            return "Atack";
        }

        public string Decrypt(string text, string Gamma)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {

                result += DecryptChar(text[i], Gamma[i]).ToString();
                Console.WriteLine(result);

            }
            return result;
        }

        public string Encrypt(string text, string Gamma)
        {
            string result = "";
            Gamma = Gamma.ToUpper();

            for (int i = 0; i < text.Length; i++)
            {

                result += EncryptChar(text[i], Gamma[i]).ToString();
            }
            return result;
        }



        private static char DecryptChar(char toDecrypt, char fromGamma)
        {
            string _toDecrypt = Alphabets.GammaDict[toDecrypt];
            string _fromGamma = Alphabets.GammaDict[fromGamma];

            string resultBinaryString = XORBinaryStrings(_toDecrypt, _fromGamma);
           
            foreach (KeyValuePair<char, string> pair in Alphabets.GammaDict)
            {
                if (pair.Value == resultBinaryString)
                {
                   
                    return pair.Key;
                    
                }
            }


            //var result = toDecrypt ^ fromGamma;
            //return (char)result;
            return 'A';
        }

        private static char EncryptChar(char toEncrypt, char fromGamma)
        {
            string _toDecrypt = Alphabets.GammaDict[toEncrypt];
            string _fromGamma = Alphabets.GammaDict[fromGamma];


            string resultBinaryString = XORBinaryStrings(_toDecrypt, _fromGamma);

            foreach (KeyValuePair<char, string> pair in Alphabets.GammaDict)
            {
                if (pair.Value == resultBinaryString)
                {
                    return pair.Key;
                }
            }

            //var result = toEncrypt ^ fromGamma;
            //return (char)result;
            return 'A';
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
