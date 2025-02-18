using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAPIAdminsManager.Model;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Helpers;
using OrderManagementAPI.Repositories;
using System.Collections.Concurrent;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly MongoDBContext _usersCollection;
        private static readonly ConcurrentDictionary<string, Session> ActiveSessions = new();

        public AuthController(MongoDBContext context)
        {
            _usersCollection = context;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Authorize request)
        {
            var existingUser = await _usersCollection.ApiUsers.Find(u => u.ApiKey == request.ApiKey).FirstOrDefaultAsync();

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(request.Password, existingUser.Password) || existingUser.ApiKey != request.ApiKey)
                return Unauthorized("Invalid credentials or API key.");

            var sessionKey = GenerateSession.GenerateSessionKey();

            var session = new Session
            {
                ApiKey = existingUser.ApiKey,
                SessionKey = sessionKey,
                ExpiryTime = DateTime.UtcNow.AddMinutes(15)
            };

            var result = ActiveSessions.TryAdd(sessionKey, session);

            return Ok(new { SessionKey = sessionKey });
        }

        #region Helper Method

        public static bool ValidateSessionKey(string sessionKey)
        {
            if (!ActiveSessions.TryGetValue(sessionKey, out var session))
                return false;

            if (session.ExpiryTime < DateTime.UtcNow)
            {
                ActiveSessions.TryRemove(sessionKey, out _); // Remove expired session
                return false;
            }

            return true;
        }

        #endregion
    }
}
