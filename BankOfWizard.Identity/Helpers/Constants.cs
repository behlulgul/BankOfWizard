namespace BankOfWizard.Identity.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string EMail = "email",
                    UserName = "user_name",
                    Rol = "rol",
                    Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
