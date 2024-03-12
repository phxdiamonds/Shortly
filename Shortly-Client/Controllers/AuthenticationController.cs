using Microsoft.AspNetCore.Mvc;
using Shortly_Client.Data.ViewModels;

namespace Shortly_Client.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Login()
        {
            //var initial = new LoginVM(); you can remove this or just pass it through thsn
            return View(new LoginVM());
        }

        public IActionResult LoginSubmitted(LoginVM loginVM)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        
    }
}
