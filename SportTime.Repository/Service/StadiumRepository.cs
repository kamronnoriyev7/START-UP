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
    public class StadiumRepository : IStadiumRepository
    {
        private readonly MainContext _context;

        public StadiumRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<long> AddStadium(Stadium stadium)
        {
            _context.Stadiums.Add(stadium);
            await _context.SaveChangesAsync();
            return stadium.StadiumId;
        }

        public async Task DeleteStadium(long stadiumId)
        {
            var stadium = await _context.Stadiums.FindAsync(stadiumId);
            if (stadium != null)
            {
                throw new Exception("stadium not found");
            }
            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();
        }

        public async Task<Stadium> GetByIdStadium(long stadiumId)
        {
            var res = await _context.Stadiums.FirstOrDefaultAsync(x => x.StadiumId == stadiumId);
            if (res is null)
            {
                throw new Exception("stadium not found");
            }
            return res;
        }

        public async Task<ICollection<Stadium>> GetStadiums()
        {
            return await _context.Stadiums.ToListAsync();
        }

        public async Task<long> UpdateStadium(Stadium stadium)
        {
            var stadiumToUpdate = await _context.Stadiums.FindAsync(stadium.StadiumId);
            if (stadiumToUpdate is null)
            {
                throw new Exception("stadium not found");
            }
            stadiumToUpdate.Name = stadium.Name;
            stadiumToUpdate.Address = stadium.Address;
            stadiumToUpdate.PhoneNumber = stadium.PhoneNumber;
            stadiumToUpdate.Price = stadium.Price;
            await _context.SaveChangesAsync();
            return stadium.StadiumId;
        }
    }
}
