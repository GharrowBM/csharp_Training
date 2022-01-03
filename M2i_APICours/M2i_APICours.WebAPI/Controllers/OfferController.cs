using M2i_APICours.Classes;
using M2i_APICours.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace M2i_APICours.WebAPI.Controllers;

[Route("offers")]
public class OfferController : ControllerBase
{
    private IRepository<Offer> _offerRepository;

    public OfferController(IRepository<Offer> offerRepository)
    {
        _offerRepository = offerRepository;
    }

    [HttpGet("/{id}")]
    public IActionResult Get(int id)
    {
        return new JsonResult(_offerRepository.GetById(id));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return new JsonResult(_offerRepository.GetAll());
    }

    [HttpDelete("/{id}")]
    public IActionResult Remove(int id)
    {
        if (_offerRepository.Remove(id))
        {
            return new JsonResult(new {message = "Deletion Done"});
        }

        return NotFound(new {message = "Can't delete that ID"});
    }

    [HttpPost]
    public IActionResult Add([FromBody] Offer offer)
    {
        if (_offerRepository.Add(offer))
        {
            return new JsonResult(new {message = "Offer added !"});
        }
        
        return NotFound(new {message = "Can't add that Offer"});

    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] Offer offer)
    {
        if (_offerRepository.Update(id, offer))
        {
            return new JsonResult(new {message= "Update Done"});
        }
        
        return NotFound(new {message = "Can't update that ID"});

    }
    
}