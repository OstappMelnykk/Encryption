

namespace EncryptionWebApplication.Services.TrithemiusEncryptionServices
{
    public class TrithemiusWatchwordEncryptionService: BaseTrithemiusEncryptionService
    {
        private string? Watchword;
        public static string watchwordLAST;
        public TrithemiusWatchwordEncryptionService() { }
        public TrithemiusWatchwordEncryptionService(string watchword){
            Watchword = watchword;
        }

        public override string Encrypt(string sourceText)
        {
            int position = 0;

            List<char> chars = new();
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (IsEncrypted(sourceText[i]))
                {
                    chars.Add(EncodeChar(sourceText[i], position));
                    position++;
                }
                else
                    chars.Add(sourceText[i]);
            }

            var toReturn = new string(chars.ToArray());

            frequencyTable = toReturn.Where(v => IsEncrypted(v)).GroupBy(v => v).ToDictionary(x => x.Key, x => x.Count());

            return toReturn;
        }

        public override string EncryptWithoutCreatingFrequencyTable(string sourceText)
        {
            int position = 0;

            List<char> chars = new();
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (IsEncrypted(sourceText[i]))
                {
                    chars.Add(EncodeChar(sourceText[i], position));
                    position++;
                }
                else
                    chars.Add(sourceText[i]);
            }

            var toReturn = new string(chars.ToArray());
            return toReturn;
        }

        public override string Decrypt(string encryptedText)
        {
            int position = 0;

            List<char> chars = new();
            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (IsEncrypted(encryptedText[i]))
                {
                    chars.Add(DecodeChar(encryptedText[i], position));
                    position++;
                }
                else
                    chars.Add(encryptedText[i]);
            }

            var toReturn = new string(chars.ToArray());
            return toReturn;
        }

        protected override int K(int position)
        {
            var symbol = Watchword[position % Watchword.Length];

            if (Alphabets.ukrainian.Contains(symbol))
                return Alphabets.ukrainian.IndexOf(symbol);

            if (Alphabets.ukrainianCapital.Contains(symbol))
                return Alphabets.ukrainianCapital.IndexOf(symbol);

            if (symbol > 64 && symbol < 91)
                return symbol - 'A';

            if (symbol > 96 && symbol < 123)
                return symbol - 'a';

            throw new Exception("Err");
        }

        public override string? Attack(string sourceText, string encryptedText)
        {
            string repeatingWatchwords =
                new(
                    ClearText(sourceText)
                    .Zip(ClearText(encryptedText))
                    .AsParallel()
                    .AsOrdered()
                    .Select(v => Moved(v.First, v.Second))
                    .Select(v => Alphabets.ukrainianCapital[v])
                    .ToArray()
                    );

            int length = 1;
            var current = repeatingWatchwords[length..];
            var answer = false;

            while (length < repeatingWatchwords.Length)
            {
                current = repeatingWatchwords[length..];

                for (int i = 0; i < repeatingWatchwords.Length; i += length)
                {
                    if (i + length <= repeatingWatchwords.Length)
                    {
                        if (repeatingWatchwords.Substring(i, length) != current)
                        {
                            answer = false;
                            break;
                        }
                    }
                    answer = true;
                }
                if (answer)
                    break;
                else
                    length++;
            }

            Watchword = SearchUniqueChars(repeatingWatchwords);


            answer = true;

			if (answer && encryptedText == EncryptWithoutCreatingFrequencyTable(sourceText))
            {
                watchwordLAST = Watchword;


				return current;
            }
            else
            {
                return null;
            }
        }

        private static string SearchUniqueChars(string str)
        {
            List<char> UniqueChars = new List<char>();
            foreach (char c in str)
            {
                if (!UniqueChars.Contains(c))
                {
                    UniqueChars.Add(c);
                }
            }
            return new string (UniqueChars.ToArray());

        }


		private static string ClearText(string givenText)
        {
            return new string(
                givenText
                .Replace("\n", "")
                .Replace("\r", "")
                .Where(x => IsEncrypted(x))
                .ToArray());
        }
    }
}
