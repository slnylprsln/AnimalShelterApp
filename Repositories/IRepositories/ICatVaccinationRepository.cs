using Entities;

namespace Data.IRepositories
{
    public interface ICatVaccinationRepository : IDisposable
    {

        IEnumerable<CatVaccination>? GetAll();
        CatVaccination? GetById(int Id);
        void Add(CatVaccination toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

