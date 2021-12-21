using Contacts.Classes;
using Contacts.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Contacts.ASPNetCoreMVC.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult GetContactList()
        {
            return View(ContactContext.Instance.Contacts.ToList());
        }

        public IActionResult GetContact(int id)
        {
            return View(ContactContext.Instance.Contacts.FirstOrDefault(c => c.Id == id));
        }

        public IActionResult NewContact()
        {
            return View();
        }

        public IActionResult DelContact(int id)
        {
            Contact c = ContactContext.Instance.Contacts.FirstOrDefault(c => c.Id == id);

            if (c != null)
            {
                ContactContext.Instance.Contacts.Remove(c);
                ContactContext.Instance.SaveChanges();
            }

            return RedirectToAction("GetContactList");
        }

        public IActionResult SubmitContact(Contact c)
        {

            ContactContext.Instance.Contacts.Add(c);
            ContactContext.Instance.SaveChanges();

            return RedirectToAction("GetContactList");
        }
        public IActionResult EditContact(int id, string lastname, string firstname, string email, string phone)
        {
            Contact c = ContactContext.Instance.Contacts.FirstOrDefault(c => c.Id == id);

            if (c != null)
            {
                c.Lastname = lastname;
                c.Firstname = firstname;
                c.Email = email;
                c.Phone = phone;

                ContactContext.Instance.Contacts.Update(c);
            }

            return RedirectToAction("GetContactList");
        }
    }
}
