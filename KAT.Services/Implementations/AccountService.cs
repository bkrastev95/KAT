using System.Runtime.InteropServices;
using System.Security;
using AutoMapper;
using KAT.IServices;
using KAT.Services.AccountWebServiceReference;
using User = KAT.Models.User.User;

namespace KAT.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly AccountWebServiceClient accountWebServiceClient;

        public AccountService()
        {
            accountWebServiceClient = new AccountWebServiceClient();
        }

        public User Login(string username, SecureString password)
        {
            var hash = HashPassword(password);
            var user = accountWebServiceClient.Login(username, hash);

            if (user == null) return null;

            Mapper.CreateMap<AccountWebServiceReference.User, User>();
            try
            {
                return Mapper.Map<User>(user);
            }
            catch (AutoMapperMappingException mapEx)
            {
                return null;
            }
        }

        private string HashPassword(SecureString password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(DecryptPassword(password));
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        private string DecryptPassword(SecureString encryptedPassword)
        {
            try
            {
                var passwordBSTR = Marshal.SecureStringToBSTR(encryptedPassword);
                return Marshal.PtrToStringBSTR(passwordBSTR);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
