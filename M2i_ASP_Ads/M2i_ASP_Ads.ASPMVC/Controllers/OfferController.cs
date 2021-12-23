using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M2i_ASP_Ads.ASPMVC.Controllers
{
    public class OfferController : Controller
    {
        private IWebHostEnvironment _env;
        private IRepository<Offer> _offerRepository;

        public OfferController(IWebHostEnvironment env, IRepository<Offer> offerRepository)
        {
            _env = env;
            _offerRepository = offerRepository;
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

        public IActionResult SubmitOffer(Offer offer, IFormFile[] offerImages)
        {
            string wwwRootPath = _env.WebRootPath;
            foreach (var image in offerImages)
            {
                string path = Path.Combine(wwwRootPath, "img", image.FileName);
                using Stream stream = System.IO.File.Create(path);
                image.CopyTo(stream);
                string basePath = "img/" + image.FileName;
                offer.Images.Add( new AdImage() { Path=basePath, Offer=offer});
            }
            
            _offerRepository.Save(offer);

            return RedirectToAction("List");
        }
    }
}
