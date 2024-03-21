using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data.ViewModels;
using Shortly_Client.Helpers.Roles;
using Shortly_Data;
using Shortly_Data.Models;
using Shortly_Data.Services;

namespace Shortly_Client.Controllers
{
 
   
    public class AuthenticationController : Controller
    {

        private IUsersService _userService;

        private SignInManager<AppUser> _signInManager;

        private UserManager<AppUser> _userManager;

        public AuthenticationController(IUsersService userService , SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;

            _userManager = userManager;

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

            //Check whether the useremail exists in the database

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                //check the user and password combination is true
                var userPassword = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if(userPassword)
                {
                    //login the user

                    var userLoggedIn = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    //redirect to home controller 

                    if (userLoggedIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt. Please check your UserName and Password");

                        return View("Login", loginVM);
                    }
                }
                else //Lockout
                {
                    await _userManager.AccessFailedAsync(user);

                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Account is locked out. Please Try Again in 5 Mins");
                        return View("Login", loginVM);
                    }


                    ModelState.AddModelError("", "Invalid login attempt. Please check your UserName and Password");
                    return View("Login", loginVM);

                }

            }

            return RedirectToAction("Index", "Home");


        }

        public async  Task<IActionResult> Register()
        {
            return View(new RegisterVM());
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async  Task<IActionResult>  RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerVM);
            }

            //checking if the user already exists
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if(user != null)
            {
                ModelState.AddModelError("", "User with this email already exists");
                return View("Register", registerVM);
            }

            //First create the user 
            var newUser = new AppUser()
            {
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                FullName = registerVM.FullName,

                LockoutEnabled = true
            };

            var createUser = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (createUser.Succeeded)
            {
                //assign the role
                 await _userManager.AddToRoleAsync(newUser, Roles.User);

                //sign n the user in

                await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);

            }
            else
            {
                foreach(var erro in createUser.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }

                return View("Register", registerVM);
            }
            

            return RedirectToAction("Index", "Home");
        }

        
    }
}
