using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Repositories;
using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IItemRepository Items { get; private set; }

        public UnitOfWork(ApplicationContext context) {
            _context = context;
            Items = new ItemRepository(_context);
        }

        public async Task<int> CompleteAsync() {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
