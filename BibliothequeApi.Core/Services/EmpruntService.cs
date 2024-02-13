using BibliothequeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApi.Services
{
    public class EmpruntService : IService<Emprunt>
    {
        private readonly IRepository<Emprunt> _repo;

        public EmpruntService(IRepository<Emprunt> repo)
        {
            _repo = repo;
        }
        public async Task<Emprunt> Add(Emprunt entity)
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

        public async Task<IEnumerable<Emprunt>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Emprunt?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Emprunt?> Update(Emprunt entity)
        {
            return await _repo.Update(entity);
        }
    }
}
