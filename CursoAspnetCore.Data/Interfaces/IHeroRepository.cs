using CursoAspNetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspnetCore.Data.Interfaces
{
    public interface IHeroRepository : IEFCoreRepository
    {
        Task<Hero> HeroById(int id);
        Task<IEnumerable<Hero>> GetAllHeroes();
    }
}
