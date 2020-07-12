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
    public class HeroRepository : EFCoreRepository, IHeroRepository
    {
        private readonly HeroContext _heroContext;

        public HeroRepository(HeroContext heroContext) : base(heroContext)
        {
            _heroContext = heroContext;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            return await _heroContext.Heroes
                .AsNoTracking()
                .Include(h => h.Weapons)
                .Include(h => h.HeroBattles)
                .ToListAsync();
        }

        public async Task<Hero> HeroById(int id)
        {
            return await _heroContext.Heroes
                .AsNoTracking()
                .Include(h => h.Weapons)
                .Include(h => h.HeroBattles)
                .FirstOrDefaultAsync(h => h.Id.Equals(id));
        }
    }
}
