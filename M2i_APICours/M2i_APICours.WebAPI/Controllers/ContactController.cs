using M2i_APICours.Classes;
using M2i_APICours.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace M2i_APICours.WebAPI.Controllers;

[Route("contacts")]
public class ContactController : ControllerBase
{
    private IRepository<Contact> _contactRepository;

    public ContactController(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return new JsonResult(_contactRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Contact contact)
    {
        _contactRepository.Add(contact);
        return Ok(new {message = "Contact Added"});
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetOne(int id)
    {
        return new JsonResult(_contactRepository.GetById(id));
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult Delete(int id)
    {
        _contactRepository.Remove(id);
        return Ok(new {message = "Deletetion Success"});
    }

    [HttpPut]
    public IActionResult Put([FromBody] Contact contact)
    {
        

        if (_contactRepository.Update(contact.Id, contact))
        {
            return Ok(new {message = "Contact Updated"});
        }

        return NotFound(new {message = "Contact not found"});
    }
}