using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using WebApp.Data.Account;
using WebApp.Services;

namespace WebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public RegisterModel(UserManager<User> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Validation de l'Email (�viter les doublons), optionnelle car on a sp�cifi� �a dans le Program.cs dans la section des Identit�s

            // Cr�ation de l'utilisateur 
            User user = new User
            {
                Email = RegisterViewModel.Email,
                UserName = RegisterViewModel.Email
            };

            var departmentClaim = new Claim("Department", RegisterViewModel.Department);
            var positionClaim = new Claim("Position", RegisterViewModel.Position);

            IdentityResult result = await _userManager.CreateAsync(user, RegisterViewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, departmentClaim);
                await _userManager.AddClaimAsync(user, positionClaim);

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.PageLink("/Account/ConfirmEmail", values: new { userId = user.Id, token = confirmationToken });

                await _emailService
                    .SendAsync("admin@web-app.com",
                    user.Email,
                    "Please confirm your email",
                    $"Please click this link to confirm your email : {confirmationLink}");

                return RedirectToPage("/Account/Login");
            }
            else
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description); // Ici Register peut-�tre string.Empty, cela ne changerait rien 
                }

                return Page();
            }

        }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
