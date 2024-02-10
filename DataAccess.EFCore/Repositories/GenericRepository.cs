using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{   
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context) {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            _context.Add(entity);
             await Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> GetAll() {
            var result = await _context.Set<T>().AsNoTracking()
                .ToListAsync();
            return result;
        }

        public async Task Remove(object id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await Task.CompletedTask;
            }
        }
    }
}
