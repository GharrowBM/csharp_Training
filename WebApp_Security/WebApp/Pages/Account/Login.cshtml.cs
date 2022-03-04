using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInMAnager;

        [BindProperty]
        public CredentialViewModel Credential { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInMAnager)
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
