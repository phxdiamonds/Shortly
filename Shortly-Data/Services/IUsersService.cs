using Shortly_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly_Data.Services
{
    public interface IUsersService
    {
        //Returns all users
        Task<List<AppUser>> GetUsersAsync();

        ////Create User
        //Task<AppUser> AddUserAsync(AppUser user);

        ////Get User by Id
        //Task<AppUser> GetUserByIdAsync(string id);

        ////Update user

        //Task<AppUser> UpdateUserAsync(string id, AppUser user);

        ////Delete User
        //Task DeleteUserAsync(string id);

        //we removed above methods, because we are using these againg with the help of usermanager and roleManager components which the asp.net identity provides

    }
}
