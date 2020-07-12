using CursoAspnetCore.Data.Interfaces;
using CursoAspNetCore.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspnetCore.Data.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _heroContext;

        public EFCoreRepository(HeroContext heroContext)
        {
            _heroContext = heroContext;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await _heroContext.AddAsync(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _heroContext.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _heroContext.Update(entity);
            _heroContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _heroContext.SaveChangesAsync()) > 0;
        }
    }
}
