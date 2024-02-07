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
    public class GenderRepository
    {
        private readonly ApplicationContext _context;
        public GenderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Gender entity)
        {
            await _context.Set<Gender>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Gender entity)
        {
            _context.Set<Gender>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Gender>> GetAllAsync()
        {
            return await _context.Set<Gender>().ToListAsync();
        }

        public Task<List<Gender>> GetAllIncludeAsync(List<string> properties)
        {
            var query = _context.Set<Gender>().AsQueryable();
            foreach (var item in properties)
            {
                if (query.GetType().GetProperty(item) != null)
                {
                    query = query.Include(item);
                }   
            }

            return query.ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            return await _context.Set<Gender>().FindAsync(id);
        }

        public async Task UpdateAsync(Gender entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
