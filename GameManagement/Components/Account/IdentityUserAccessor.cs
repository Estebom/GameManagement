using GameManagement.Data;
using Microsoft.AspNetCore.Identity;

namespace GameManagement.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<GameManagementUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<GameManagementUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
