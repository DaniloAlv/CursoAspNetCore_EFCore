using CursoAspNetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspnetCore.Data.Interfaces
{
    public interface IBattleRepository : IEFCoreRepository
    {
        Task<IEnumerable<Battle>> GetAllBattles();
        Task<Battle> BattleById(int id);
    }
}
