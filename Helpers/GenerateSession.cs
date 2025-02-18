namespace OrderManagementAPI.Helpers
{
    public class GenerateSession
    {
        public static string GenerateSessionKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789=$&@";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 25)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
