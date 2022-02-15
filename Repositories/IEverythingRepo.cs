using Is2MinutesBackend.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Is2MinutesBackend.Repositories
{
    public interface IEverythingRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Add(T obj);
        Task Delete(T obj);
        Task<T> Update(T obj);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
      
    }
}
