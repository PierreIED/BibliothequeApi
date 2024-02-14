using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class AuteurRepository : IRepository<Auteur>
    {
        private readonly BibliothequeContext _context;

        public AuteurRepository(BibliothequeContext context)
        {
            this._context = context;
        }

        public async Task<Auteur> Add(Auteur entity)
        {
            _context.Auteurs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            Auteur auteur = _context.Auteurs.Find(id)!;
            if (auteur == null)
            {
                return false;
            }
            _context.Auteurs.Remove(auteur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Auteur>> GetAll()
        {
            return await _context.Auteurs.ToListAsync();
        }

        public async Task<Auteur?> GetById(int id)
        {
            return await _context.Auteurs
                .Include(d => d.Livres)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Auteur?> Update(Auteur entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
