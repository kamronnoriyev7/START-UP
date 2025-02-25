using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
    public interface IUserService
    {
        Task<long> AddUser(User user);
        Task<long> UpdateUser(User user);
        Task DeleteUser(long userId);
        Task<User> GetByIdUser(long userId);
        Task<ICollection<User>> GetUsers();
        Task<bool> SaveUserPhoneNumber(long userId, string phoneNumber);
        Task<bool> CheckAdmin(long userId);
    }
}
