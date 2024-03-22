using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data.ViewModels;
using Shortly_Client.Helpers.Roles;
using Shortly_Data;
using Shortly_Data.Models;
using Shortly_Data.Services;
using System.Security.Claims;

namespace Shortly_Client.Controllers
{
    public class UrlController : Controller
    {
        

        private IUrlsService _urlService;
        private readonly IMapper _mapper;
        public UrlController(IUrlsService urlService, IMapper mapper)
        {

            _urlService = urlService;
            _mapper = mapper;

        }
        public  async Task<IActionResult> Index()
        {

            //in the view the data is getting from GetUrlVM so we have to map to GetUrlVM
            //var allUrlsFromDb = _urlService.GetUrls().Select(x => new GetUrlVM()
            //{
            //    Id = x.Id,
            //    OriginalLink = x.OriginalLink,
            //    ShortLink = x.ShortLink,
            //    NoOfClicks = x.NoOfClicks,
            //    UserId = x.UserId,

            //    User = x.User != null ? new GetUserVM() { Id = x.User.Id, FullName = x.User.FullName } : null

            //}).ToList();

            //Need to check the user is Admin or not, and need to have logged in id

            var LoggedInUser = User.FindFirstValue(ClaimTypes.NameIdentifier);//returns user id
            var isAdmin = User.IsInRole(Roles.Admin);



              

            //Replacing the above code with mapper



            var allUrlsFromDb = await  _urlService.GetUrlsAsync(LoggedInUser, isAdmin );
            var mappedUrls = _mapper.Map<List<GetUrlVM>>(allUrlsFromDb);

            //another way is doing is mapping both the source and destination
           // var mappedUrls = _mapper.Map<List<Url>,List<GetUrlVM>>(allUrlsFromDb);

            return View(mappedUrls); //passing the get of urlvms to the view

            //Select * from Urls
            //select Id, originallink, shortlink, noofclicks, userid from Urls

        }

        //Tempdata

        public async Task<IActionResult> Create()
        {
      

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            //we are using the id which is passed from the view to this action, to remove the item from database

            await _urlService.DeleteUrlAsync(id);

            //so we have removed, now we need to return to index
            return RedirectToAction("Index");
        }


    }
}
