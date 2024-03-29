﻿using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class LecteurService : IService<Lecteur>
    {
        private readonly IRepository<Lecteur> _repo;

        public LecteurService(IRepository<Lecteur> repo)
        {
            _repo = repo;
        }
        public async Task<Lecteur> Add(Lecteur entity)
        {
            return await _repo.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<Lecteur>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Lecteur?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Lecteur?> Update(Lecteur entity)
        {
            return await _repo.Update(entity);
        }
    }
}
