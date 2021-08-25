using Mtbs.Models.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public interface IAuthService
    {
        Task<ApplicationUser> Login(string userName, string password);

        Task<RegisterResultCode> Register(string usreName, string email, string password);
        
        Task<RegisterResultCode> RegisterAdmin(string userName, string email, string password);

        Task<IEnumerable<string>> GetUserRoles(ApplicationUser user);
    }

    public enum RegisterResultCode
    {
        UserAlreadyExists,
        UserRegistrationFailed,
        Succeeded
    }
}
