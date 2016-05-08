using System;
using System.Data;
using System.Linq;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Web.Models;

namespace KAT.Data.Services
{
    public class AccountService : IAccountService
    {
        public User Login(string username, string password)
        {
            CodeFirstModels.User user;

            try
            {
                using (var db = new KatDataContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                }
            }
            catch (DataException datEx)
            {
                return null;
            }

            if (user == null) return null;

            return new User
            {
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                FullName = user.FullName
            };
        }
    }
}
