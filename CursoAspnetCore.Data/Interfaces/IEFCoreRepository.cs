using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspnetCore.Data.Interfaces
{
    public interface IEFCoreRepository
    {
        Task Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
