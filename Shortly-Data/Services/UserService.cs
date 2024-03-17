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

        public async  Task<User> AddUserAsync(User user)
        {
           await _context.Users.AddAsync(user);

           await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var allUsers =  await _context.Users.Include(u => u.Urls).ToListAsync();

            return allUsers;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public  async  Task<User> UpdateUserAsync(int id, User user)
        {
           var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(userDb != null)
            {
                userDb.Email = user.Email;
                userDb.FullName = user.FullName;

                _context.SaveChanges();
            }

            return userDb;
        }

        public async Task  DeleteUserAsync(int id)
        {
           var userDb = await  _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(userDb != null)
            {
                _context.Users.Remove(userDb);
               await  _context.SaveChangesAsync();
            }


        } 
    }
}
