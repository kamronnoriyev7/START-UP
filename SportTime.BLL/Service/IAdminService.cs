using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
   public interface IAdminService
    {
        Task<long> AddAdmin(Admin admin);
        Task<long> UpdateAdmin(Admin admin);
        Task DeleteAdmin(long adminId);
        Task<Admin> GetByIdAdmin(long adminId);
        Task<ICollection<Admin>> GetAdmins();
        Task<bool> IsAdminExist(string password);
    }
}
