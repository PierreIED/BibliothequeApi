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

        public async Task Delete(int id)
        {
            Adresse domaine = _context.Adresses.Find(id)!;
            _context.Adresses.Remove(domaine);
            await _context.SaveChangesAsync();
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
