using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class AuteurService : Interfaces.IService<Auteur>
    {
        private readonly IRepository<Auteur> _repo;

        public AuteurService(IRepository<Auteur> repo)
        {
            _repo = repo;
        }
        public async Task<Auteur> Add(Auteur entity)
        {
            return await _repo.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            if (_repo.GetById(id) == null)
            {
                return false;
            }
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Auteur>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Auteur?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Auteur?> Update(Auteur entity)
        {
            return await _repo.Update(entity);
        }
    }
}
