using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data.ViewModels;
using Shortly_Data;

namespace Shortly_Client.Controllers
{
 
   
    public class AuthenticationController : Controller
    {
        private AppDbContext _context;

        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Users()
        {
            var users = _context.Users.Include(x => x.Urls).ToList();
            
            return View(users);
        }

        //renders the login form
        public IActionResult Login()
        {
            //var initial = new LoginVM(); you can remove this or just pass it through thsn
            return View(new LoginVM());
        }

        public IActionResult LoginSubmitted(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }
            //redirect to home controller 
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        public IActionResult RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerVM);
            }
            return RedirectToAction("Index", "Home");
        }

        
    }
}
