using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using M2i_ASP_Ads.ASPMVC.Services;

namespace M2i_ASP_Ads.ASPMVC.Controllers
{
    public class OfferController : Controller
    {
        private IWebHostEnvironment _env;
        private IRepository<Offer> _offerRepository;
        private LoginService _loginService;
        private FavoriteService _favoriteService;

        public OfferController(IWebHostEnvironment env, IRepository<Offer> offerRepository,
            LoginService loginService, FavoriteService favoriteService)
        {
            _env = env;
            _offerRepository = offerRepository;
            _loginService = loginService;
            _favoriteService = favoriteService;
        }

        public IActionResult List()
        {
            return View(_offerRepository.GetAll());
        }

        public IActionResult Filter(string filter)
        {
            return View("List", (_offerRepository.Search(x => x.Title == filter || x.Description == filter)));
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
            _loginService.Login(user.UserName, user.Password);

            return RedirectToAction("List");
        }

        public IActionResult Logout()
        {
            _loginService.Logout();
                
            return RedirectToAction("List");
        }

        public IActionResult AddFav(int id)
        {
            _favoriteService.AddFavorite(id);

            return RedirectToAction("List");
        }

        public IActionResult RemFav(int id)
        {
            _favoriteService.RemoveFavorite(id);

            return RedirectToAction("List");
        }

        public IActionResult GetFavs()
        {
            return RedirectToAction("List", _favoriteService.GetFavorites());
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