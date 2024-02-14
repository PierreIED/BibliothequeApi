using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class EmpruntRepository: IRepository<Emprunt>
    {
        private readonly BibliothequeContext _context;

        public EmpruntRepository(BibliothequeContext context)
        {
            this._context = context;
        }

        public async Task<Emprunt> Add(Emprunt entity)
        {
            _context.Emprunts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            Emprunt emprunt = _context.Emprunts.Find(id)!;
            if (emprunt == null)
            {
                return false;
            }
            _context.Emprunts.Remove(emprunt);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Emprunt>> GetAll()
        {
            return await _context.Emprunts.ToListAsync();
        }

        public async Task<Emprunt?> GetById(int id)
        {
            return await _context.Emprunts
                .Include(d => d.Livre)
                .Include(e => e.Lecteur)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Emprunt?> Update(Emprunt entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

