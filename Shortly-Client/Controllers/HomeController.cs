using Microsoft.AspNetCore.Mvc;
using Shortly_Client.Data.ViewModels;
using System.Diagnostics;

namespace Shortly_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //for the initial render to work, you need to pass the post url vm as a parameter of the view
            //creating a new empty object and pass 
            var newUrl = new PostUrlVM();
            return View(newUrl);
        }

        //Creating a method to handle the form request
        //sending a posturlVm from the view, so need to have a parameter
        public IActionResult ShortenUrl(PostUrlVM postUrlVM)
        {
            //validate the Model

            if (!ModelState.IsValid)
            {
                return View("Index", postUrlVM);
            }
           // return View("Index");
            return RedirectToAction("Index");
        }

   
    }
}
