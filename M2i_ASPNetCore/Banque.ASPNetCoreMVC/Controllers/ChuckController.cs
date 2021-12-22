using Banque.ASPNetCoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Banque.ASPNetCoreMVC.Controllers
{
    public class ChuckController : Controller
    {
        private ToolsService _toolsService;
        private CheckService _checkService;

        public ChuckController(ToolsService toolsService, CheckService checkService)
        {
            _toolsService = toolsService;
            _checkService = checkService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chucked(string s)
        {
            return new ContentResult() { Content = _toolsService.ConvertToChuckNorrisCode(s) };
        }

        public IActionResult CheckPass(string s)
        {
            return new ContentResult() { Content = _checkService.CheckPassword(s) };
        }
    }
}
