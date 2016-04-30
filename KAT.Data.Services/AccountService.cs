using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Web.Models;

namespace KAT.Data.Services
{
    public class AccountService : IAccountService
    {
        public User Login(string username, SecureString password)
        {
            var decryptedPassword = DecryptPassword(password);
            CodeFirstModels.User user;
            using (var db = new KatDataContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == decryptedPassword);
            }

            if (user == null) return null;

            Mapper.CreateMap<User, CodeFirstModels.User>();
            return Mapper.Map<User>(user);
        }

        private string DecryptPassword(SecureString encryptedPassword)
        {
            string decryptedPassword;
            try
            {
                var passwordBSTR = Marshal.SecureStringToBSTR(encryptedPassword);
                return decryptedPassword = Marshal.PtrToStringBSTR(passwordBSTR);
            }
            catch
            {
                return decryptedPassword = "";
            }
        }
    }
}
