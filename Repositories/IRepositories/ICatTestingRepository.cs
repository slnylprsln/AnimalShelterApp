using Entities;

namespace Data.IRepositories
{
    public interface ICatTestingRepository : IDisposable
    {

        IEnumerable<CatTesting>? GetAll();
        CatTesting? GetById(int Id);
        void Add(CatTesting toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

