using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class DomaineService : IService<Domaine>
    {
        private readonly IRepository<Domaine> _repo;

        public DomaineService(IRepository<Domaine> repo)
        {
            _repo = repo;
        }
        public async Task<Domaine> Add(Domaine entity)
        {
            return await _repo.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<Domaine>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Domaine?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Domaine?> Update(Domaine entity)
        {
            return await _repo.Update(entity);
        }
    }
}
