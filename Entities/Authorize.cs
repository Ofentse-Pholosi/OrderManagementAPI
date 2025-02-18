namespace OrderManagementAPI.Entities
{
    public class Authorize
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }
}
