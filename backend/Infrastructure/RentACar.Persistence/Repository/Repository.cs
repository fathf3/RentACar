using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities.Common;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly RentACarContext _context;
        public DbSet<T> Table => _context.Set<T>();
        public Repository(RentACarContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.SingleOrDefaultAsync(filter);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
