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
        List<Url> GetUrls();

        //Add Url
        Url AddUrl(Url url);

        //Get Url by id
        Url GetUrlById(int id);

        //Update Url
        Url UpdateUrl(int id, Url url);

        //delete Url
        void DeleteUrl(int id);

    }
}
