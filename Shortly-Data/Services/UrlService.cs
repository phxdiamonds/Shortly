using Microsoft.EntityFrameworkCore;
using Shortly_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly_Data.Services
{
    public class UrlService : IUrlsService
    {
        //In this service we are goint to inject the dbcontext bexause Moving forward we are not using dbcontext directly in the controller, we will use the service instead
        //service is used the dbcontext to communicate witht the database

        private AppDbContext _context;

        public UrlService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Url> AddUrlAsync(Url url)
        {
          await  _context.Urls.AddAsync(url);
           await _context.SaveChangesAsync();

            return url;
        }

        public async  Task<List<Url>>  GetUrlsAsync(string userId, bool isAdmin)
        {

            //Get the urls from db with users so we can include the user with Include 
            var allUrls =  _context.Urls.Include(u => u.User);

            if (isAdmin)
            {
                return await allUrls.ToListAsync();
            }
            else
            {
                return await allUrls.Where(u => u.UserId == userId).ToListAsync();
            }


            

            
        }

        public async Task<Url> GetUrlByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);
            return url;
        }

        public async Task<Url> UpdateUrlAsync(int id, Url url)
        {
            //Get the Url frm db by id
            //update the values which we receive from front end
            //save changes

            var urlDb =  await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);

            if(urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.UtcNow;
            }

           await _context.SaveChangesAsync();

            return urlDb;


        }

        public async Task DeleteUrlAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);

            if(urlDb != null)
            {
                _context.Urls.Remove(urlDb);
              await _context.SaveChangesAsync();
            }
        }
    }
}