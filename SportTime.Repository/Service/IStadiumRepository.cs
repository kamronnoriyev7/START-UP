using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.Repository.Service
{
    public interface IStadiumRepository
    {
        Task<long> AddStadium(Stadium stadium);
        Task<long> UpdateStadium(Stadium stadium);
        Task DeleteStadium(long stadiumId);
        Task<Stadium> GetByIdStadium(long stadiumId);
        Task<ICollection<Stadium>> GetStadiums();
    }
}
