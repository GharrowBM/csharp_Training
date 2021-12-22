using Banque.Classes;
using Banque.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Banque.ASPNetCoreMVC.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewAccount()
        {
            return View();
        }

        public IActionResult SubmitAccount(Account account)
        {
            BankContext.Instance.Accounts.Add(account);
            BankContext.Instance.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditAccount(int id)
        {
            Account account = BankContext.Instance.Accounts.Include(a => a.Client).Include(a => a.Operations).FirstOrDefault(a => a.Id == id);

            return View(account);
        }

        public IActionResult RemoveAccount(int id)
        {
            Account account = BankContext.Instance.Accounts.FirstOrDefault(a => a.Id == id);

            if (account != null)
            {
                BankContext.Instance.Accounts.Remove(account);
                BankContext.Instance.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult NewClient()
        {
            return View();
        }

        public IActionResult SubmitClient(Client client)
        {
            BankContext.Instance.Clients.Add(client);
            BankContext.Instance.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditClient(int id, string firstname, string lastname, string email, string phone)
        {
            Client client = BankContext.Instance.Clients.Include(c=>c.Accounts).FirstOrDefault(c => c.Id == id);

            if (client != null)
            {
                client.Firstname = firstname;
                client.Lastname = lastname;
                client.Email = email;
                client.Phone = phone;

                BankContext.Instance.Clients.Update(client);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveClient(int id)
        {
            Client client = BankContext.Instance.Clients.FirstOrDefault(c => c.Id == id);

            if (client != null)
            {
                BankContext.Instance.Clients.Remove(client);
                BankContext.Instance.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult NewOperation(int id)
        {
            Account account = BankContext.Instance.Accounts.Include(a => a.Client).Include(a => a.Operations).FirstOrDefault(a => a.Id == id);

            return View(account);
        }

        public IActionResult SubmitOperation(int id, Operation operation)
        {
            Account account = BankContext.Instance.Accounts.Include(a => a.Client).Include(a => a.Operations).FirstOrDefault(a => a.Id == id);
            account.Operations.Add(operation);
            BankContext.Instance.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
