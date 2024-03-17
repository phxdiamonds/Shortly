using Microsoft.EntityFrameworkCore;
using Shortly_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly_Data.Services
{
    public class UserService : IUsersService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }

        public List<User> GetUsers()
        {
            var allUsers = _context.Users.Include(u => u.Urls).ToList();

            return allUsers;
        }

        User IUsersService.GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        User IUsersService.UpdateUser(int id, User user)
        {
           var userDb = _context.Users.FirstOrDefault(u => u.Id == id);

            if(userDb != null)
            {
                userDb.Email = user.Email;
                userDb.FullName = user.FullName;

                _context.SaveChanges();
            }

            return userDb;
        }

        void IUsersService.DeleteUser(int id)
        {
           var userDb = _context.Users.FirstOrDefault(u => u.Id == id);

            if(userDb != null)
            {
                _context.Users.Remove(userDb);
                _context.SaveChanges();
            }


        } 
    }
}
