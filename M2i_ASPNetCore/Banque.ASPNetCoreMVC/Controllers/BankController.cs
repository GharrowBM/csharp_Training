using Microsoft.AspNetCore.Mvc;

namespace Banque.ASPNetCoreMVC.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
