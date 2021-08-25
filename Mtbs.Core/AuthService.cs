using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Mtbs.Models.Authentication;
using System.Collections.Generic;

namespace Mtbs.Core
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if(user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        public async Task<RegisterResultCode> Register(string userName, string email, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            if(existingUser != null)
            {
                return RegisterResultCode.UserAlreadyExists;
            }
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return RegisterResultCode.UserRegistrationFailed;
            }

            return RegisterResultCode.Succeeded;
        }

        public async Task<RegisterResultCode> RegisterAdmin(string userName, string email, string password)
        {
            var result = await Register(userName, email, password);

            if(result != RegisterResultCode.Succeeded)
            {
                return result;
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            var user = await _userManager.FindByNameAsync(userName);
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return RegisterResultCode.Succeeded;
        }

        public async Task<IEnumerable<string>> GetUserRoles(ApplicationUser user)
        {
            if (user != null)
            {
                return await _userManager.GetRolesAsync(user);
            }

            return null;
        }
    }
}
