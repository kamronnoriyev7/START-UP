using Microsoft.EntityFrameworkCore;
using SportTime.DAL;
using SportTime.DAL.Entities;

namespace SportTime.Repository.Service
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MainContext _context;

        public AdminRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<long> AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin.AdminId;
        }

        public async Task DeleteAdmin(long adminId)
        {
            var admin = await _context.Admins.FindAsync(adminId);
            if (admin != null)
            {
                throw new Exception("admin not found");
            }
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Admin>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetByIdAdmin(long adminId)
        {
            var res = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == adminId);
            if (res is null)
            {
                throw new Exception("admin not found");
            }
            return res;
        }

        public async Task<bool> IsAdminExist(string password)
        {
            return await _context.Admins.AnyAsync(x => x.Password == password);
        }

        public async Task<long> UpdateAdmin(Admin admin)
        {
            var adminToUpdate = await _context.Admins.FindAsync(admin.AdminId);
            if (adminToUpdate is null)
            {
                throw new Exception("admin not found");
            }
            adminToUpdate.Name = admin.Name;
            adminToUpdate.Number = admin.Number;
            adminToUpdate.Email = admin.Email;
            adminToUpdate.Password = admin.Password;
            await _context.SaveChangesAsync();
            return admin.AdminId;
        }
    }
}
