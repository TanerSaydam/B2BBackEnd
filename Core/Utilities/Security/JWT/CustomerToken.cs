namespace Core.Utilities.Security.JWT
{
    public class CustomerToken
    {
        public string CustomerAccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
