using SportTime.DAL.Entities;
using SportTime.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<long> AddAdmin(Admin admin)
        {
            return await _adminRepository.AddAdmin(admin);
        }

        public async Task DeleteAdmin(long adminId)
        {
            await _adminRepository.DeleteAdmin(adminId);
        }

        public async Task<ICollection<Admin>> GetAdmins()
        {
            return await _adminRepository.GetAdmins();
        }

        public async Task<Admin> GetByIdAdmin(long adminId)
        {
            return await _adminRepository.GetByIdAdmin(adminId);
        }

        public async Task<bool> IsAdminExist(string password)
        {
            return await _adminRepository.IsAdminExist(password);
        }

        public async Task<long> UpdateAdmin(Admin admin)
        {
            return await _adminRepository.UpdateAdmin(admin);
        }
    }
}
