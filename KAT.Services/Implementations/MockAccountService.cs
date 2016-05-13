using System.Security;
using KAT.IServices;
using KAT.Models.User;

namespace KAT.Services.Implementations
{
    public class MockAccountService : IAccountService
    {
        public User Login(string username, SecureString encryptedPassword)
        {
            return new User
            {
                FullName = "Боян Кръстев",
                IsAdmin = true
            };
        }
    }
}
