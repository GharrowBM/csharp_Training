using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApp.Data.Account;

namespace WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInMAnager;

        [BindProperty]
        public CredentialViewModel Credential { get; set; }

        public LoginModel(SignInManager<User> signInMAnager)
        {
            _signInMAnager = signInMAnager;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _signInMAnager.PasswordSignInAsync(Credential.Email,
                Credential.Password,
                Credential.RememberMe,
                false);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            } 
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "You are locked out !");
                }
                else
                {
                    ModelState.AddModelError("Login", "Failed to Login...");

                }
            }

            return Page();
        }
    }

    public class CredentialViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set;}
    }
}
