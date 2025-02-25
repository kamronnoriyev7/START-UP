using Microsoft.EntityFrameworkCore;
using SportTime.DAL;
using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.Repository.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<long> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<bool> CheckAdmin(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            return user.IsAdmin;
        }

        public async Task DeleteUser(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                throw new Exception("user not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdUser(long userId)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (res is null)
            {
                throw new Exception("user not found");
            }
            return res;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async  Task<bool> SaveUserPhoneNumber(long userId, string phoneNumber)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            user.PhoneNumber = phoneNumber;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<long> UpdateUser(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.UserId);
            if (userToUpdate is null)
            {
                throw new Exception("user not found");
            }
            userToUpdate.Name = user.Name;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.Password = user.Password;
            userToUpdate.CreatedDate = user.CreatedDate;
            await _context.SaveChangesAsync();
            return user.UserId;
        }
    }
}
