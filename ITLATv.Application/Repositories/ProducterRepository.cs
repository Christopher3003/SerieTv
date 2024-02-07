using ITLATv.Database.Context;
using ITLATv.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.Repositories
{
    public class ProducterRepository
    {
        private readonly ApplicationContext _context;
        public ProducterRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Producter entity)
        {
            await _context.Set<Producter>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Producter entity)
        {
            _context.Set<Producter>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producter>> GetAllAsync()
        {
            return await _context.Set<Producter>().ToListAsync();
        }

        public Task<List<Producter>> GetAllIncludeAsync(List<string> properties)
        {
            var query = _context.Set<Producter>().AsQueryable();
            foreach (var item in properties)
            {
                if (query.GetType().GetProperty(item) != null)
                {
                    query = query.Include(item);
                }
            }

            return query.ToListAsync();
        }

        public async Task<Producter> GetByIdAsync(int id)
        {
            return await _context.Set<Producter>().FindAsync(id);
        }

        public async Task UpdateAsync(Producter entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

    }
}
