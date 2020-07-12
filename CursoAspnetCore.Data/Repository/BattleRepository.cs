using CursoAspnetCore.Data.Interfaces;
using CursoAspNetCore.Domain.Models;
using CursoAspNetCore.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspnetCore.Data.Repository
{
    public class BattleRepository : EFCoreRepository, IBattleRepository
    {
        private readonly HeroContext _heroContext;

        public BattleRepository(HeroContext heroContext) : base(heroContext)
        {
            _heroContext = heroContext;
        }

        public async Task<Battle> BattleById(int id)
        {
            return await _heroContext.Battles
                .AsNoTracking()
                .Include(b => b.HeroBattles)
                .FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<Battle>> GetAllBattles()
        {
            return await _heroContext.Battles
                .AsNoTracking()
                .Include(b => b.HeroBattles)
                .ToListAsync();
        }
    }
}
