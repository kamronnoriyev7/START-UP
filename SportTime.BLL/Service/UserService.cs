using SportTime.DAL.Entities;
using SportTime.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task<bool> CheckAdmin(long userId)
        {
            return await _userRepository.CheckAdmin(userId);
        }

        public async Task DeleteUser(long userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public async Task<User> GetByIdUser(long userId)
        {
            return await _userRepository.GetByIdUser(userId);
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<bool> SaveUserPhoneNumber(long userId, string phoneNumber)
        {
            return await _userRepository.SaveUserPhoneNumber(userId, phoneNumber);  
        }

        public async Task<long> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}
