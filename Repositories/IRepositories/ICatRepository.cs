using Entities;

namespace Data.IRepositories
{
    public interface ICatRepository : IDisposable
    {

        IEnumerable<Cat>? GetAll();
        Cat? GetById(int Id);
        void Add(Cat toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

