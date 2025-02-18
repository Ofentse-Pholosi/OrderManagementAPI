namespace OrderManagementAPI.Entities
{
    public class Session
    {
        public string ApiKey { get; set; } = string.Empty;
        public string SessionKey { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
    }
}
