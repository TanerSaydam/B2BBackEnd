namespace Core.Utilities.Security.JWT
{
    public class AdminToken
    {
        public string AdminAccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
