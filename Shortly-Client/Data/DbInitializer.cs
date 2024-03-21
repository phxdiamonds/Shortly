using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Identity.Client;
using Shortly_Client.Helpers.Roles;
using Shortly_Data;
using Shortly_Data.Models;

namespace Shortly_Client.Data
{
    //the reason i'm creating a static class is because, whenever i want access method within this class  i don't need to initialize   a new object again
    public static class DbInitializer
    {
        //public static void SeedDefautData(IApplicationBuilder applicationBuilder)
        //{
        //    //create a scope for the application services

        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //get the reference of the appDbContext
        //        var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        //create default user and url

        //        if (!dbContext.Users.Any())
        //        {
        //            dbContext.Users.AddRange(new AppUser()
        //            { FullName = "Mike", Email = "mike@me.com" },new AppUser()
        //            { FullName = "John", Email = "john@me.com" }, new AppUser()
        //            { FullName = "Jane", Email = "jane@me.com" });

        //            dbContext.SaveChanges();

        //        }
        //    }

        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //get the reference of the appDbContext
        //        var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        //Create the default url
        //        if (!dbContext.Urls.Any())
        //        {
        //            dbContext.Urls.AddRange(new Url()
        //            {
        //                OriginalLink = "https://www.google.com",
        //                ShortLink = "https://short.ly/1",
        //                NoOfClicks=2,
        //                UserId = dbContext.Users.First().Id,
        //                DateCreated = DateTime.Now
                        
        //            }, new Url()
        //            {
        //                OriginalLink = "https://www.facebook.com",
        //                ShortLink = "https://short.ly/2",
        //                NoOfClicks = 3,
        //                UserId = dbContext.Users.First().Id,
        //                DateCreated = DateTime.Now
        //            }, new Url()
        //            {
        //                OriginalLink = "https://www.microsoft.com",
        //                ShortLink = "https://short.ly/3",
        //                NoOfClicks = 4,
        //                UserId = dbContext.Users.First().Id,
        //                DateCreated = DateTime.Now
        //            });

        //            dbContext.SaveChanges();

        //        }

        //    }
        //}

        //Creating a new method for creating user manager and roles manager to create roles , create users and assign roles to the users

        public static async Task SeedDefaultUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            //if you want ot have access to a service in this file, what you need to do is in progrma file, you need to add that service to the container
            //Here we are "using" statement because whenever the code execution goes to this line, the reference is closed
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Create references for role manager

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //User Manager

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                //simple User related data

                //first create role, create user and assign role to user

                var simpleUserRole = Roles.User;
                var simpleUserEmail = "user@shortly.com";

                if(!await roleManager.RoleExistsAsync(simpleUserRole))
                {
                    await roleManager.CreateAsync(new IdentityRole(){ Name = simpleUserRole });
                }

                 
                if(await userManager.FindByEmailAsync(simpleUserEmail) == null)
                {
                    //create user 
                    var simpleUser = new AppUser()
                    {
                        FullName = "Simple User",
                        UserName = "simple-user",
                        Email = simpleUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(simpleUser, "Password@123");

                    //add user to role

                    await userManager.AddToRoleAsync(simpleUser, simpleUserRole);


                }

                //Admin Related Data

                var adminRole = Roles.Admin;
                var adminEmail = "admin@shortly.com";

                if(!await roleManager.RoleExistsAsync(adminRole))
                {
                    await roleManager.CreateAsync(new IdentityRole(){ Name = adminRole });
                }

                if(await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    //Create Admin

                    var adminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Password@123");

                    //add admin to role

                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }

            }
        }
    }
}
