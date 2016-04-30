using System.Security;
using KAT.Models.User;

namespace KAT.IServices
{
    public interface IAccountService
    {
        User Login(string username, SecureString encryptedPassword);
    }
}
