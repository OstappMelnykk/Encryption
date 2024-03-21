using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionWebApplication
{
    public static class Alphabets
    {
        public static readonly List<char> ukrainian =
            "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя".ToList();

        public static readonly List<char> ukrainianCapital =
            "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ".ToList();

        public const int ukrainianLen = 33;

        public const int englishLen = 26;

        public static bool IsUkrainian(char letter)
        {
            return ukrainian.Contains(letter) || ukrainianCapital.Contains(letter);
        }

        public static bool IsEnglish(char letter)
        {
            return IsCapitalEnglish(letter) || IsSmallEnglish(letter);
        }

        public static bool IsCapitalEnglish(char letter)
        {
            return (letter > 64 && letter < 91);
        }

        public static bool IsSmallEnglish(char letter)
        {
            return (letter > 96 && letter < 123);
        }
    }
}
