using Microsoft.AspNetCore.Mvc;
using Shortly_Client.Data.ViewModels;
using Shortly_Data;
using Shortly_Data.Models;
using System.Diagnostics;

namespace Shortly_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
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

            //Create an object of the Url
            var newUrl = new Url() { OriginalLink = postUrlVM.Url, ShortLink = GenerateShortLink(6), NoOfClicks = 0, UserId = null,DateCreated = DateTime.UtcNow};

            //add object to the EF Context

            _context.Urls.Add(newUrl);

            _context.SaveChanges();

            TempData["Message"]=$"Your Url was shorted Successfully to {newUrl.ShortLink}";

           // return View("Index");
            return RedirectToAction("Index");
        }

        //Creating a method to generate the shortedned link

        private string GenerateShortLink(int length)
        {
            var random = new Random();


            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            //Generate the string based upon the chars we are having up here, by randomly selecting up chars based upon the length given in the parameter
            //we need to create the reference of the random class

            //Here enumerable repeat method which is repeated in chars string based upon the length,
            //to get randonly i'm selecting using select method and then converting into array
            //and fianlly converting to string because of new string at the beginning

            return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());




        }

   
    }
}
