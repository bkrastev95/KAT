using System.Security;
using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface IAccountService
    {
        User Login(string username, string encryptedPassword);
    }
}
