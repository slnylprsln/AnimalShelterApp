using Entities;

namespace Data.IRepositories
{
    public interface IDogRepository : IDisposable
    {

        IEnumerable<Dog>? GetAll();
        Dog? GetById(int Id);
        void Add(Dog toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

