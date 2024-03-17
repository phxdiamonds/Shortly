using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data.ViewModels;
using Shortly_Data;
using Shortly_Data.Services;

namespace Shortly_Client.Controllers
{
 
   
    public class AuthenticationController : Controller
    {

        private IUsersService _userService;

        public AuthenticationController(IUsersService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Users()
        {
            var users = await _userService.GetUsersAsync();
            
            return View(users);
        }

        //renders the login form
        public async Task<IActionResult> Login()
        {
            //var initial = new LoginVM(); you can remove this or just pass it through thsn
            return View(new LoginVM());
        }

        public async Task<IActionResult> LoginSubmitted(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }
            //redirect to home controller 
            return RedirectToAction("Index", "Home");
        }

        public async  Task<IActionResult> Register()
        {
            return View(new RegisterVM());
        }

        public async  Task<IActionResult>  RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerVM);
            }
            return RedirectToAction("Index", "Home");
        }

        
    }
}
