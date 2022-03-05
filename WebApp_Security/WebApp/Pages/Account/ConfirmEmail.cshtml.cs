using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Account;

namespace WebApp.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> _usermanager;

        [BindProperty]
        public string Message { get; set; }

        public ConfirmEmailModel(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }
        public async Task<IActionResult> OnGetAsync(string userId, string token)
        {
            var user = await _usermanager.FindByIdAsync(userId);
            if (user is not null)
            {
                var result = await _usermanager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    Message = "Email successfully confirmed, now you can try to login.";
                    return Page();
                }
            }

            Message = "Failed to validate Email.";
            return Page();
        }
    }
}
