using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class DogDiseaseHistoryRepository : IDisposable, IDogDiseaseHistoryRepository
    {
        public DogDiseaseHistoryDbContext context;
        public DogDiseaseHistoryRepository(DogDiseaseHistoryDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<DogDiseaseHistory>? GetAll()
        {
            var list = context.DogDiseaseHistories.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public DogDiseaseHistory? GetById(int Id)
        {
            DogDiseaseHistory found = new();
            if (found == null)
            {
                return null;
            }
            else return context.DogDiseaseHistories.Find(Id);
        }
        public void Add(DogDiseaseHistory toAdd)
        {
            context.DogDiseaseHistories.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            DogDiseaseHistory? toDelete = context.DogDiseaseHistories.Find(Id);
            if (toDelete != null)
            {
                context.DogDiseaseHistories.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            DogDiseaseHistory? toUpdate = context.DogDiseaseHistories.Find(Id);
            if (toUpdate != null)
            {
                context.Update(toUpdate);
                SaveChanges();
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        private bool dispose = false;
        public virtual void Dispose(bool disposing)
        {
            if (dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
