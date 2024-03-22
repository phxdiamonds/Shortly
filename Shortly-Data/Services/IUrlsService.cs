using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Shortly_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly_Data.Services
{
    public interface IUrlsService
    {
        //Get allUrls
        Task<List<Url>> GetUrlsAsync(string userId, bool isAdmin);

        //Add Url
       Task<Url> AddUrlAsync(Url url);

        //Get Url by id
        Task<Url> GetUrlByIdAsync(int id);

        //Update Url
        Task<Url> UpdateUrlAsync(int id, Url url);

        //delete Url
        Task DeleteUrlAsync(int id);

    }
}
