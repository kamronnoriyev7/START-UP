using SportTime.DAL.Entities;
using SportTime.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
    public class StadiumService : IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;

        public StadiumService(IStadiumRepository stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        public async Task<long> AddStadium(Stadium stadium)
        {
            return await _stadiumRepository.AddStadium(stadium);
        }

        public async Task DeleteStadium(long stadiumId)
        {
            await _stadiumRepository.DeleteStadium(stadiumId);
        }

        public async Task<Stadium> GetByIdStadium(long stadiumId)
        {
            return await _stadiumRepository.GetByIdStadium(stadiumId);
        }

        public async Task<ICollection<Stadium>> GetStadiums()
        {
            return await _stadiumRepository.GetStadiums();
        }

        public async Task<long> UpdateStadium(Stadium stadium)
        {
            return await _stadiumRepository.UpdateStadium(stadium);
        }
    }
}
