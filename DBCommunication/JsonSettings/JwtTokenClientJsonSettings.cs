namespace DBCommunication.JsonSettings
{
    public class JwtTokenClientJsonSettings
    {
        public int UserDataImplementation { get; set; }
        public int AccessTokenExpiresTimeInMinutes { get;  set; }
        public int RefreshTokenExpiresTimeInMinutes { get; set; }
        public string ClientSecret { get; set; }
    }
}
