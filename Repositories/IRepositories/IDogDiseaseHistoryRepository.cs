using Entities;

namespace Data.IRepositories
{
    public interface IDogDiseaseHistoryRepository : IDisposable
    {

        IEnumerable<DogDiseaseHistory>? GetAll();
        DogDiseaseHistory? GetById(int Id);
        void Add(DogDiseaseHistory toAdd);
        void Delete(int Id);
        void Update(int Id);
        void SaveChanges();
        void Dispose(bool disposing);
        void Dispose();
    }
}

