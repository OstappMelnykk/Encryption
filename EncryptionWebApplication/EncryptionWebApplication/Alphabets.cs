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


        public static readonly Dictionary<char, string> GammaDict = new Dictionary<char, string>()
        {
            {'A', "00000"},
            {'B', "00001"},
            {'C', "00010"},
            {'D', "00011"},
            {'E', "00100"},
            {'F', "00101"},
            {'G', "00110"},
            {'H', "00111"},
            {'I', "01000"},
            {'J', "01001"},
            {'K', "01010"},
            {'L', "01011"},
            {'M', "01100"},
            {'N', "01101"},
            {'O', "01110"},
            {'P', "01111"},
            {'Q', "10000"},
            {'R', "10001"},
            {'S', "10010"},
            {'T', "10011"},
            {'U', "10100"},
            {'V', "10101"},
            {'W', "10110"},
            {'X', "10111"},
            {'Y', "11000"},
            {'Z', "11001" },
        };
    }
}
