using Microsoft.AspNetCore.Mvc;
using Shortly_Client.Data.Models;
using Shortly_Client.Data.ViewModels;

namespace Shortly_Client.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            //Fake Db Data

            var allUrls = new List<GetUrlVM>()
            {
                new GetUrlVM(){ Id =1, OriginalLink = "www.google.com", ShortLink = "www.google.com", NoOfClicks = 5, UserId = 1},
                new GetUrlVM(){ Id =2, OriginalLink = "www.facebook.com", ShortLink = "www.facebook.com", NoOfClicks = 2, UserId = 3},
                new GetUrlVM(){ Id =3, OriginalLink = "www.microsoft.com", ShortLink = "www.microsoft.com", NoOfClicks = 1, UserId = 2},
                new GetUrlVM(){ Id =4, OriginalLink = "www.microsoft.com", ShortLink = "www.microsoft.com", NoOfClicks = 4, UserId = 4},
                new GetUrlVM(){ Id =5, OriginalLink = "www.microsoft.com", ShortLink = "www.microsoft.com", NoOfClicks = 3, UserId = 5}
            };

            return View(allUrls); //passing the get of urlvms to the view

        }

        //Tempdata

        public IActionResult Create()
        {
      

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            return View();
        }

        public IActionResult Remove(int userId, int linkId)
        {
            return View();
        }
    }
}
