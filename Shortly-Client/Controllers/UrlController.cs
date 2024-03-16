using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data.ViewModels;
using Shortly_Data;

namespace Shortly_Client.Controllers
{
    public class UrlController : Controller
    {
        private AppDbContext _context { get; set; }
        public UrlController(AppDbContext context)
        {

            _context = context;

        }
        public IActionResult Index()
        {

            //in the view the data is getting from GetUrlVM so we have to map to GetUrlVM
            var allUrlsFromDb = _context.Urls.Include(x => x.User).Select(x => new GetUrlVM()
            {
                Id = x.Id,
                OriginalLink = x.OriginalLink,
                ShortLink = x.ShortLink,
                NoOfClicks = x.NoOfClicks,
                UserId = x.UserId,

                User = x.User != null ? new GetUserVM() { Id = x.User.Id, FullName = x.User.FullName } : null

            }).ToList();

            return View(allUrlsFromDb); //passing the get of urlvms to the view

            //Select * from Urls
            //select Id, originallink, shortlink, noofclicks, userid from Urls

        }

        //Tempdata

        public IActionResult Create()
        {
      

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            //we are using the id which is passed from the view to this action, to remove the item from database

            var url = _context.Urls.FirstOrDefault(x => x.Id == id);

            if(url != null)
            {
                _context.Urls.Remove(url);
                _context.SaveChanges();
            }
            
            //so we have removed, now we need to return to index
            return RedirectToAction("Index");
        }


    }
}
