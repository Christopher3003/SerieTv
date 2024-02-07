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
    public class SerieRepository
    {
        private readonly ApplicationContext _context;
        public SerieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Serie entity)
        {
            await _context.Set<Serie>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie entity)
        {
            _context.Set<Serie>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetAllAsync()
        {
            return await _context.Set<Serie>().ToListAsync();
        }

        public Task<List<Serie>> GetAllIncludeAsync(List<string> properties)
        {
            var query = _context.Set<Serie>().AsQueryable();
            foreach (var item in properties)
            {
                if (query != null)
                {
                    query = query.Include(item);
                }           
            }

            return query.ToListAsync();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {
            return await _context.Set<Serie>().FindAsync(id);
        }

        public async Task<string> GetSecondaryGenderById(int? id)
        {
            var serie = await _context.Set<Serie>().FindAsync(id);
            return serie.Name;
        }

        public async Task UpdateAsync(Serie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }      
    }
}
