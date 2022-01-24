namespace BankOfWizard.Identity.Helpers
{
    public class ClaimStorage
    {
        public string[] Claims { get; }

        public ClaimStorage(string[] claims)
        {
            Claims = claims;
        }
    }
}
