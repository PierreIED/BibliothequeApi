using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class LivreRepository : IRepository<Livre>
    {
        private readonly BibliothequeContext _context;

        public LivreRepository(BibliothequeContext context)
        {
            this._context = context;
        }

        public async Task<Livre> Add(Livre entity)
        {
            _context.Livres.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            Livre domaine = _context.Livres.Find(id)!;
            _context.Livres.Remove(domaine);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livre>> GetAll()
        {
            return await _context.Livres.ToListAsync();
        }

        public async Task<Livre?> GetById(int id)
        {
            return await _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.Domaine)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Livre?> Update(Livre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

