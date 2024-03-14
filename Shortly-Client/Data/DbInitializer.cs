using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Shortly_Data;
using Shortly_Data.Models;

namespace Shortly_Client.Data
{
    //the reason i'm creating a static class is because, whenever i want access method within this class  i don't need to initialize   a new object again
    public static class DbInitializer
    {
        public static void SeedDefautData(IApplicationBuilder applicationBuilder)
        {
            //create a scope for the application services

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //get the reference of the appDbContext
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //create default user and url

                if (!dbContext.Users.Any())
                {
                    dbContext.Users.AddRange(new User()
                    { FullName = "Mike", Email = "mike@me.com" },new User()
                    { FullName = "John", Email = "john@me.com" }, new User()
                    { FullName = "Jane", Email = "jane@me.com" });

                    dbContext.SaveChanges();

                }
            }

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //get the reference of the appDbContext
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //Create the default url
                if (!dbContext.Urls.Any())
                {
                    dbContext.Urls.AddRange(new Url()
                    {
                        OriginalLink = "https://www.google.com",
                        ShortLink = "https://short.ly/1",
                        NoOfClicks=2,
                        UserId = dbContext.Users.First().Id,
                        DateCreated = DateTime.Now
                        
                    }, new Url()
                    {
                        OriginalLink = "https://www.facebook.com",
                        ShortLink = "https://short.ly/2",
                        NoOfClicks = 3,
                        UserId = dbContext.Users.First().Id,
                        DateCreated = DateTime.Now
                    }, new Url()
                    {
                        OriginalLink = "https://www.microsoft.com",
                        ShortLink = "https://short.ly/3",
                        NoOfClicks = 4,
                        UserId = dbContext.Users.First().Id,
                        DateCreated = DateTime.Now
                    });

                    dbContext.SaveChanges();

                }

            }
        }
    }
}
