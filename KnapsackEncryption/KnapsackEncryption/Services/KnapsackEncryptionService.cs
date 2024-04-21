using DocumentFormat.OpenXml.Drawing.Charts;

namespace KnapsackEncryption.Services
{
    public class KnapsackEncryptionService
    {
        public string Encrypt(string sourceText, List<int> W, int q, int r, List<int> B)
        {           
            List<int> EncryptedText = new List<int>();

            for (int i = 0; i < sourceText.Length; i++)
                EncryptedText.Add(EncryptChar(sourceText[i], W, q, r, B));

            return "(" + string.Join(" ", EncryptedText) + ")"; ;
        }


        public int EncryptChar(char symbol, List<int> W, int q, int r, List<int> B)
        {
            List<int> binaryDigits = CharToBInary(symbol);
           
            int sum = 0;
            for (int j = 0; j < binaryDigits.Count; j++)
                sum += binaryDigits[j] * B[j];

            return sum;
        }




        public string Decrypt(string sourceText, List<int> W, int q, int r)
        {
            List<int> numbers = sourceText
                .Trim('(', ')') 
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            string DectyptedText = "";

            for (int i = 0; i < numbers.Count; i++)
            {
                int rDash = ModInverse(r, q);
                int cDash = (numbers[i] * rDash) % q;

                List<int> X = Decompose(cDash, W);


                int m = 0;

                for (int j = 0; j < X.Count; j++)
                {
                    m += (int)Math.Pow(2, 8 - X[j]);
                }

                DectyptedText += ((char)m).ToString();
            }

            return DectyptedText;
        }

       /* public char DencryptChar(int symbol, List<int> W, int q, int r, List<int> B)
        {


            int rDash = ModInverse(r, q);
            int cDash = (symbol * rDash) % q;

            List<int> X = Decompose(cDash, W);


            int m = 0;

            for (int i = 0; i < X.Count; i++)
            {
                m += (int)Math.Pow(2, 8 - X[i]);
            }


            return ' ';
        }*/



        static List<int> CharToBInary(char symbol)
        {
            int asciiCode = (int)symbol;
            string binaryAsciiCode = Convert.ToString(asciiCode, 2).PadLeft(8, '0');

            return binaryAsciiCode.Select(binaryDigit => binaryDigit - '0').ToList();
        }




        static List<int> ConvertStringToListOfBits(char symbol)
        {
            int asciiCode = (int)symbol;
            string binaryAsciiCode = Convert.ToString(asciiCode, 2).PadLeft(8, '0');

            List<int> binaryDigits = new List<int>();

            foreach (char binaryDigit in binaryAsciiCode) binaryDigits.Add(binaryDigit - '0');

            return binaryDigits;
        }


        static List<int> Decompose(int c, List<int> W)
        {
            List<int> indexes = new List<int>();

            while (c > 0)
            {
                int largestIndex = -1;
                for (int i = 0; i < W.Count; i++)
                {
                    if (W[i] <= c)
                        largestIndex = i;
                }

                if (largestIndex == -1)
                    break;

                c -= W[largestIndex];
                indexes.Add(largestIndex + 1);
            }

            return indexes;
        }



        static int ModInverse(int r, int q)
        {
            int m0 = q;
            int y = 0, x = 1;

            if (q == 1)
                return 0;

            while (r > 1)
            {
                int p = r / q;
                int t = q;

                q = r % q;
                r = t;
                t = y;

                y = x - p * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }


    }
}
