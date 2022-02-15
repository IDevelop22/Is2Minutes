using Is2MinutesBackend.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Is2MinutesBackend.Repositories
{
    public class EverythingRepo<T>:IEverythingRepo<T> where T:class
    {
        private readonly Is2MinutesContext _context;

        public EverythingRepo(Is2MinutesContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(T obj)
        {
             _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }
                
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }


    }
}
