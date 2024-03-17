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
        List<User> GetUsers();

        //Create User
        User AddUser(User user);

        //Get User by Id
        User GetUserById(int id);

        //Update user

        User UpdateUser(int id, User user);

        //Delete User
        void DeleteUser(int id);
    }
}
