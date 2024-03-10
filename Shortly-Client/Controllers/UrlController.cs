using Microsoft.AspNetCore.Mvc;
using Shortly_Client.Data.Models;

namespace Shortly_Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //Data is from Database

            //var urlDb = new List<Url>()
            //{
            // new Url{
            //    //Define some properties
            //    Id = 1,
            //    OriginalLink = "https://www.google.com",
            //    ShortLink = "https://goo.gl",
            //    NoOfClicks = 1,
            //    UserId = 1 
            // },

            // new Url
            // {
            //    Id = 2,
            //    OriginalLink = "https://www.facebook.com",
            //    ShortLink = "https://fb.me",
            //    NoOfClicks = 1,
            //    UserId = 2
            // }
            //};

            //var urlData = new List<Url>();
            //urlData = urlDb;

            //return View(urlData);

            //View Data

            //ViewData["shortenedUrl"] = "This is just a short url";
            //ViewData["AllUrls"] = new List<string>() { "Url 1", "Url 2", "Url 3" };

            //return View();


            //ViewBag

            //ViewBag.shortenedUrl = "This is just a short url";

            //ViewBag.AllUrls = new List<string>() { "Url 1", "Url 2", "Url 3" };

            //return View();

            //TempData

            if(TempData["SuccessMessage"] != null)
            {
                var tempData = TempData["SuccessMessage"];
                var viewBag = ViewBag.Test1;
                var viewData = ViewData["Test2"];

                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            return View();

        }

        //Tempdata

        public IActionResult Create()
        {
            //shorten url
            var shortenedUrl = "Short Url";

            TempData["SuccessMessage"] = "SuccessFull";

            ViewBag.Test1 = "Test1";
            ViewData["Test2"] = "Test2";

            return RedirectToAction("Index");
        }
    }
}
