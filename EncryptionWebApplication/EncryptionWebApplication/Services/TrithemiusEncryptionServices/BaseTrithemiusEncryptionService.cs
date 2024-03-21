using EncryptionWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionWebApplication.Services.TrithemiusEncryptionServices
{
    public abstract class BaseTrithemiusEncryptionService
    {
        public Dictionary<char, int> frequencyTable = new();
        protected abstract int K(int p);
        public abstract string? Attack(string sourceText, string encryptedText);


        public virtual string Decrypt(string sourceText) => new string(sourceText.Select((v, i) => DecodeChar(v, i)).ToArray());


        public virtual string Encrypt(string sourceText)
        {
            var toReturn = new string(sourceText.Select((v, i) => EncodeChar(v, i)).ToArray());
            frequencyTable = toReturn.Where(v => IsEncrypted(v)).GroupBy(v => v).ToDictionary(x => x.Key, x => x.Count());
            return toReturn;
        }
        public virtual string EncryptWithoutCreatingFrequencyTable(string sourceText) => new string(sourceText.Select((v, i) => EncodeChar(v, i)).ToArray());


        protected virtual char EncodeChar(char X_symbol, int p)
        {
            if (Alphabets.ukrainian.Contains(X_symbol)){
                var x = Alphabets.ukrainian.IndexOf(X_symbol);
                int y = (x + K(p)) % Alphabets.ukrainianLen;
                if (y < 0) y += Alphabets.ukrainianLen;
                return Alphabets.ukrainian[y];
            }

            if (Alphabets.ukrainianCapital.Contains(X_symbol)){
                var x = Alphabets.ukrainianCapital.IndexOf(X_symbol);
                int y = (x + K(p)) % Alphabets.ukrainianLen;
                if (y < 0) y += Alphabets.ukrainianLen;
                return Alphabets.ukrainianCapital[y];
            }

            if (X_symbol > 64 && X_symbol < 91){
                int x = X_symbol - 'A';
                int y = (x + K(p)) % Alphabets.englishLen;
                if (y < 0) y += Alphabets.englishLen;
                return (char)(y + 'A');
            }

            if (X_symbol > 96 && X_symbol < 123){
                int x = X_symbol - 'a';
                int y = (x + K(p)) % Alphabets.englishLen;
                if (y < 0) y += Alphabets.englishLen;
                return (char)(y + 'a');
            }

            return X_symbol;
        }

        protected char DecodeChar(char Y_symbol, int p)
        {
            if (Alphabets.ukrainian.Contains(Y_symbol)){
                var y = Alphabets.ukrainian.IndexOf(Y_symbol);
                int x = (y - K(p)) % Alphabets.ukrainianLen;
                if (x < 0) x += Alphabets.ukrainianLen;
                return Alphabets.ukrainian[x];
            }

            if (Alphabets.ukrainianCapital.Contains(Y_symbol)){
                var y = Alphabets.ukrainianCapital.IndexOf(Y_symbol);
                int x = (y - K(p)) % Alphabets.ukrainianLen;
                if (x < 0) x += Alphabets.ukrainianLen;
                return Alphabets.ukrainianCapital[x];
            }

            if (Y_symbol > 64 && Y_symbol < 91){
                int y = Y_symbol - 'A';
                int x = (y - K(p)) % Alphabets.englishLen;
                if (x < 0) x += Alphabets.englishLen;
                return (char)(x + 'A');
            }

            if (Y_symbol > 96 && Y_symbol < 123){
                int y = Y_symbol - 'a';
                int x = (y - K(p)) % Alphabets.englishLen;
                if (x < 0) x += Alphabets.englishLen;
                return (char)(x + 'a');
            }

            return Y_symbol;
        }

        protected static bool IsEncrypted(char letter)
        {
            if (    
                Alphabets.ukrainian.Contains(letter) || 
                Alphabets.ukrainianCapital.Contains(letter) || 
                (letter > 64 && letter < 91) || 
                (letter > 96 && letter < 123)
               )
            {
                return true;
            }          
            return false;
        }

        protected virtual int Moved(char before, char after)
        {
            if ((after > 64 && after < 91) || (after > 96 && after < 123))
            {
                return (after - before < 0) ? (after - before + Alphabets.englishLen) : (after - before);
            }
            if (Alphabets.ukrainian.Contains(after))
            {
                var tempMoved = Alphabets.ukrainian.IndexOf(after) - Alphabets.ukrainian.IndexOf(before);

                return (tempMoved < 0) ? (tempMoved + Alphabets.ukrainianLen) : tempMoved;
            }
            if (Alphabets.ukrainianCapital.Contains(after))
            {
                var tempMoved = Alphabets.ukrainianCapital.IndexOf(after) - Alphabets.ukrainianCapital.IndexOf(before);

                return (tempMoved < 0) ? (tempMoved + Alphabets.ukrainianLen) : tempMoved;
            }
            return 0;
        }
    }
}
