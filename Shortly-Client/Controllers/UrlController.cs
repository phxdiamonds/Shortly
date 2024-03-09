using Microsoft.AspNetCore.Mvc;

namespace Shortly_Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
