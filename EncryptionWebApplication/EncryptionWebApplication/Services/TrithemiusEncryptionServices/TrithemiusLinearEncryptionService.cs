namespace EncryptionWebApplication.Services.TrithemiusEncryptionServices
{
    public class TrithemiusLinearEncryptionService : BaseTrithemiusEncryptionService
    {
        public int A;
        public int B;

        public TrithemiusLinearEncryptionService() { }
        public TrithemiusLinearEncryptionService(int _A, int _B)
        {
            A = _A;
            B = _B;
        }

        protected override int K(int p) => A * p + B;

        public override string? Attack(string sourceText, string encryptedText)
        {
            List<int> charIndexes = new();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (IsEncrypted(encryptedText[i]))
                    charIndexes.Add(i);

                if (charIndexes.Count > 1)
                {
                    int p1 = charIndexes[0];
                    int p2 = charIndexes[1];

                    //get k for both encrypted chars
                    var moved1 = Moved(sourceText[p1], encryptedText[p1]);
                    var moved2 = Moved(sourceText[p2], encryptedText[p2]);

                    //calculate parA from equation system
                    int parA = (moved2 - moved1) / (p2 - p1);

                    //calculate parB from first equation
                    int parB = moved1 - (p1 * parA);

                    A = parA;
                    B = parB;

                    return $"{A},{B}";
                }
            }          
            return null;
        }
    }
}
