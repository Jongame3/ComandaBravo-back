namespace ComBravo.BusinessLogic.Structure
{
    public static class JwtSettings
    {
        public const string Issuer = "ComBravoApi";
        public const string Audience = "ComBravoClients";
        public const string SecretKey = "ilovepisatibackendochensilnocomadabravovpered";
        public const int ExpireMinutes = 60;
    }
}
