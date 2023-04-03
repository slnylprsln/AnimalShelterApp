using Entities;

namespace Data.IRepositories
{
    public interface IShelterRepository : IDisposable
    {

        IEnumerable<Shelter>? GetAll();
        Shelter? GetById(int Id);
        void Add(Shelter toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

