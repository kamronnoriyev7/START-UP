using SportTime.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTime.BLL.Service
{
    public interface IStadiumService
    {
        Task<long> AddStadium(Stadium stadium);
        Task<long> UpdateStadium(Stadium stadium);
        Task DeleteStadium(long stadiumId);
        Task<Stadium> GetByIdStadium(long stadiumId);
        Task<ICollection<Stadium>> GetStadiums();
    }
}
