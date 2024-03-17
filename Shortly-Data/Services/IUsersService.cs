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
        Task<List<User>> GetUsersAsync();

        //Create User
        Task<User> AddUserAsync(User user);

        //Get User by Id
        Task<User> GetUserByIdAsync(int id);

        //Update user

        Task<User> UpdateUserAsync(int id, User user);

        //Delete User
        Task DeleteUserAsync(int id);
    }
}
