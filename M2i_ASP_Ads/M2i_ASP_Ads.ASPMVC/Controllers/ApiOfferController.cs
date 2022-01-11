using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;
using Microsoft.AspNetCore.Mvc;

namespace M2i_ASP_Ads.ASPMVC.Controllers;

[Route("/api/v1")]
public class ApiOfferController : Controller
{
    private IWebHostEnvironment _env;
    private IRepository<Offer> _offerRepository;

    public ApiOfferController(IWebHostEnvironment env, IRepository<Offer> offerRepository)
    {
        _env = env;
        _offerRepository = offerRepository;
    }
    
    [HttpGet("/{offerId}")]
    public IActionResult Get(int offerId)
    {
        return Ok(_offerRepository.Get(offerId));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_offerRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromForm] IFormFile[] offerImages, [FromForm] Offer offer)
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

            if (_offerRepository.Save(offer))
            {
                return Ok(new {Message = "Offer added!"});
            }
            else
            {
                return NotFound(new {Message = "Cannot add this offer..."});
            }



    }
}