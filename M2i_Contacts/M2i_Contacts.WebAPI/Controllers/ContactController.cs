using M2i_Contacts.Classes;
using M2i_Contacts.Repositories.Interfaces;
using M2i_Contacts.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace M2i_Contacts.WebAPI.Controllers;

[Route("contacts")]
public class ContactController : Controller
{
    private IRepository<Contact> _contactRepository;
    private UploadService _uploadService;

    public ContactController(IRepository<Contact> contactRepository, UploadService uploadService)
    {
        _contactRepository = contactRepository;
        _uploadService = uploadService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_contactRepository.GetAll());
    }

    [HttpGet("/{contactId}")]
    public IActionResult Get(int contactId)
    {
        return Ok(_contactRepository.Get(contactId));
    }

    [HttpPost]
    public IActionResult Post([FromForm] IFormFile avatar, [FromForm] Contact contact)
    {
        contact.Avatar.FilePath = _uploadService.Upload(avatar);
        
        if (_contactRepository.Add(contact)) return Ok(new {Message = "Contact added!"});

        return NotFound(new {Message = "Contact addition failed..."});
    }
}