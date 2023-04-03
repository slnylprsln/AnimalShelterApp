using Entities;

namespace Data.IRepositories
{
    public interface ICatDiseaseHistoryRepository : IDisposable
    {

        IEnumerable<CatDiseaseHistory>? GetAll();
        CatDiseaseHistory? GetById(int Id);
        void Add(CatDiseaseHistory toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

