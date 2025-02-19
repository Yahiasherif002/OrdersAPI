using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbset.AddAsync(entity);

        public void Delete(T entity) => _dbset.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbset.ToListAsync();

        public async Task<T?> GetById(Guid id) => await _dbset.FindAsync(id);

        public void Update(T entity) => _dbset.Update(entity);
    }
}
