using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class LivreService : IService<Livre>
    {
        private readonly IRepository<Livre> _repo;

        public LivreService(IRepository<Livre> repo)
        {
            _repo = repo;
        }
        public async Task<Livre> Add(Livre entity)
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

        public async Task<IEnumerable<Livre>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Livre?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Livre?> Update(Livre entity)
        {
            return await _repo.Update(entity);
        }
    }
}
