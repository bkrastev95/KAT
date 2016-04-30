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
            var user = accountWebServiceClient.Login(username, password);

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
    }
}
