using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class AdresseService : IService<Adresse>
    {
        private readonly IRepository<Adresse> _repo;

        public AdresseService(IRepository<Adresse> repo)
        {
            _repo = repo;
        }
        public async Task<Adresse> Add(Adresse entity)
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

        public async Task<IEnumerable<Adresse>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Adresse?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Adresse?> Update(Adresse entity)
        {
            return await _repo.Update(entity);
        }
    }
}

