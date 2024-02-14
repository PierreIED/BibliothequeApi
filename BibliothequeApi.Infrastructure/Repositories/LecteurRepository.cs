using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class LecteurRepository: IRepository<Lecteur>
    {
        private readonly BibliothequeContext _context;

        public LecteurRepository(BibliothequeContext context)
        {
            this._context = context;
        }

        public async Task<Lecteur> Add(Lecteur entity)
        {
            _context.Lecteurs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            Lecteur lecteur = _context.Lecteurs.Find(id)!;
            if (lecteur == null)
            {
                return false;
            }
            _context.Lecteurs.Remove(lecteur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Lecteur>> GetAll()
        {
            return await _context.Lecteurs.ToListAsync();
        }

        public async Task<Lecteur?> GetById(int id)
        {
            return await _context.Lecteurs
                .Include(l => l.Adresse)
                .Include(l => l.Emprunter)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Lecteur?> Update(Lecteur entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}

