﻿using BibliothequeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Repositories
{
    public class DomaineRepository : IRepository<Domaine>
    {
        private readonly BibliothequeContext _context;

        public DomaineRepository(BibliothequeContext context)
        {
            this._context = context;
        }

        public async Task<Domaine> Add(Domaine entity)
        {
            _context.Domaines.Add(entity);
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

        public async Task<IEnumerable<Domaine>> GetAll()
        {
            return await _context.Domaines.ToListAsync();
        }

        public async Task<Domaine?> GetById(int id)
        {
            return await _context.Domaines
                .Include(d=> d.Livres)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Domaine?> Update(Domaine entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
