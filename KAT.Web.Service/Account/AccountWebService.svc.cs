using System.Security;
using KAT.Data.IServices;
using KAT.Web.Models;
using KAT.Web.Service.Ninject;
using Ninject;

namespace KAT.Web.Service.Account
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountWebService.svc or AccountWebService.svc.cs at the Solution Explorer and start debugging.
    public class AccountWebService : IAccountWebService
    {
        private readonly IAccountService accountService;
        public AccountWebService()
        {
            NinjectConfig.ConfigureContainer();
            accountService = NinjectConfig.Kernel.Get<IAccountService>();
        }
        public User Login(string username, SecureString password)
        {
            return accountService.Login(username, password);
        }
    }
}
