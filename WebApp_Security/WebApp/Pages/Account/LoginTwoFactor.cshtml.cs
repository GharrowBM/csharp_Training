using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApp.Data.Account;
using WebApp.Services;

namespace WebApp.Pages.Account
{
    public class LoginTwoFactorModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<User> _signInManager;

        [BindProperty]
        public EmailMFA EmailMFA { get; set; }

        public LoginTwoFactorModel(UserManager<User> userManager, 
            IEmailService emailService,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;

            EmailMFA = new EmailMFA();
        }
        public async Task OnGetAsync(string email, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            EmailMFA.SecurityCode = String.Empty;
            EmailMFA.RememberMe = rememberMe;

            var securityCode = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            await _emailService.SendAsync("admin@web-app.com",
                email,
                "My Web App's OTP",
                $"Please visit use this code as the OTP: {securityCode}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _signInManager.TwoFactorSignInAsync("Email", EmailMFA.SecurityCode, EmailMFA.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login2FA", "You are locked out !");
                }
                else
                {
                    ModelState.AddModelError("Login2FA", "Failed to Login...");

                }
            }

            return Page();
        }
    }

    public class EmailMFA
    {
        [Required]
        [Display(Name ="Security Code")]
        public string SecurityCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
