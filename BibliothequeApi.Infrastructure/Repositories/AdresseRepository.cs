using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class AdresseRepository : IRepository<Adresse>
    {
        private readonly BibliothequeContext _context;

        public AdresseRepository(BibliothequeContext context)
        {
            _context = context;
        }

        public async Task<Adresse> Add(Adresse entity)
        {
            _context.Adresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            Adresse adresse = _context.Adresses.Find(id)!;
            if (adresse == null)
            {
                return false;
            }
            _context.Adresses.Remove(adresse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Adresse>> GetAll()
        {
            return await _context.Adresses.ToListAsync();
        }

        public async Task<Adresse?> GetById(int id)
        {
            return await _context.Adresses
                .Include(a => a.Lecteurs)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Adresse?> Update(Adresse entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
