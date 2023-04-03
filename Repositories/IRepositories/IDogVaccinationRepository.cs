using Entities;

namespace Data.IRepositories
{
    public interface IDogVaccinationRepository : IDisposable
    {

        IEnumerable<DogVaccination>? GetAll();
        DogVaccination? GetById(int Id);
        void Add(DogVaccination toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

