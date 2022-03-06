using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using WebApp.Data.Account;

namespace WebApp.Pages.Account
{
    [Authorize]
    public class AthenticatorWithMFASetupModel : PageModel
    {
        private readonly UserManager<User> _usermanager;

        [BindProperty]
        public SetupMFAViewModel VM { get; set; }

        [BindProperty]
        public bool Succeeded { get; set; }

        public AthenticatorWithMFASetupModel(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
            VM = new SetupMFAViewModel();
            Succeeded = false;
        }

        public async Task OnGetAsync()
        {
            var user = await _usermanager.GetUserAsync(base.User);
            await _usermanager.ResetAuthenticatorKeyAsync(user);
            var key = await _usermanager.GetAuthenticatorKeyAsync(user);
            VM.Key = key;
            VM.QRCodeBytes = GenerateQRCodeBytes("Wep App", key, user.Email);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _usermanager.GetUserAsync(base.User);
            if(await _usermanager.VerifyTwoFactorTokenAsync(user,
                _usermanager.Options.Tokens.AuthenticatorTokenProvider,
                VM.SecurityCode))
            {
                await _usermanager.SetTwoFactorEnabledAsync(user, true);
                Succeeded = true;
            }
            else
            {
                ModelState.AddModelError("AuthenticatorSetup", "Something went wrong with authenticator setup.");
            }

            return Page();
        }

        private Byte[] GenerateQRCodeBytes(string provider, string key, string userEmail)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(
                $"otpauth://totop/{provider}:{userEmail}?secret={key}&issuer={provider}",
                QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            return BitmapToByteArray(qrCodeImage);
        }

        private Byte[] BitmapToByteArray(Bitmap image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }

    public class SetupMFAViewModel
    {
        public string Key { get; set; }

        [Required]
        [Display(Name ="Security Code")]
        public string SecurityCode { get; set; }

        public Byte[] QRCodeBytes { get; set; }
    }
}
