using Entities;

namespace Data.IRepositories
{
    public interface IDogTestingRepository : IDisposable
    {

        IEnumerable<DogTesting>? GetAll();
        DogTesting? GetById(int Id);
        void Add(DogTesting toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

