using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace M2i_ASP_Ads.ASPMVC.Controllers
{
    public class OfferController : Controller
    {
        private IWebHostEnvironment _env;
        private IRepository<Offer> _offerRepository;
        private IRepository<User> _userRepository;

        public OfferController(IWebHostEnvironment env, IRepository<Offer> offerRepository,
            IRepository<User> userRepository)
        {
            _env = env;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
        }

        public IActionResult List()
        {
            
            return View(_offerRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_offerRepository.Get(id));
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SubmitUser(User user)
        {
            if (_userRepository.Search(u => u.UserName == user.UserName && u.Password == user.Password)
                    .FirstOrDefault() != null)
            {
                Request.HttpContext.Session.SetString("connected", "yes");
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public IActionResult Logout()
        {
            Request.HttpContext.Session.SetString("connected", "no");
            return RedirectToAction("List");
        }

        public IActionResult SubmitOffer(Offer offer, IFormFile[] offerImages)
        {
            bool isConnected = Request.HttpContext.Session.GetString("connected") == "yes";
            
            if (isConnected)
            {
                string wwwRootPath = _env.WebRootPath;
                foreach (var image in offerImages)
                {
                    string path = Path.Combine(wwwRootPath, "img", image.FileName);
                    using Stream stream = System.IO.File.Create(path);
                    image.CopyTo(stream);
                    string basePath = "img/" + image.FileName;
                    offer.Images.Add(new AdImage() {Path = basePath, Offer = offer});
                }

                _offerRepository.Save(offer);

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }
    }
}