using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class CatDiseaseHistoryRepository : IDisposable, ICatDiseaseHistoryRepository
    {
        public CatDiseaseHistoryDbContext context;
        public CatDiseaseHistoryRepository(CatDiseaseHistoryDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CatDiseaseHistory>? GetAll()
        {
            var list = context.CatDiseaseHistories.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public CatDiseaseHistory? GetById(int Id)
        {
            CatDiseaseHistory found = new();
            if (found == null)
            {
                return null;
            }
            else return context.CatDiseaseHistories.Find(Id);
        }
        public void Add(CatDiseaseHistory toAdd)
        {
            context.CatDiseaseHistories.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            CatDiseaseHistory? toDelete = context.CatDiseaseHistories.Find(Id);
            if (toDelete != null)
            {
                context.CatDiseaseHistories.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            CatDiseaseHistory? toUpdate = context.CatDiseaseHistories.Find(Id);
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
