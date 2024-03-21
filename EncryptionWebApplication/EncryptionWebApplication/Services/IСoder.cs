namespace EncryptionWebApplication.Services
{
    public interface ICoder
    {
        string Encrypt(string sourceText, int step);
        string Decrypt(string sourceText, int step);
        string? Attack(string sourceText, string encryptedText);
    }

}
