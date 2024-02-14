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
        public async Task<Emprunt?> Add(Emprunt entity)
        {
            return EmpruntConditions(entity) ? await _repo.Add(entity) : null;


        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
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


        public static bool EmpruntConditions(Emprunt entity)

        {
            if(DateEmpruntEstToday(entity))
            {
                return true;
            }
            return false;
        }

        public static bool DateEmpruntEstToday(Emprunt entity)
        {
            return entity.DateEmprunt.Equals(DateOnly.FromDateTime(DateTime.Now));
        }
        public static bool DateEmpruntAvantDateRetour(Emprunt entity)
        {
            if(entity.DateRetour == null) { return false; }
            if(entity.DateEmprunt.CompareTo(entity.DateRetour) <= 0) { return true; }
            return false;
        }
        public static bool DateRetourEstToday(Emprunt entity)
        {
            return entity.DateRetour.Equals(DateOnly.FromDateTime(DateTime.Now));
        }

    }
}
