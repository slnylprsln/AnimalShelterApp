using Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IDisposable
    {

        IEnumerable<User>? GetAll();
        User? GetByUsername(string username);
        User? GetById(int? Id);
        void Add(User toAdd);
        void Delete(int? Id);
        void Update(int? Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

