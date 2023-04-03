using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class CatTestingRepository : IDisposable, ICatTestingRepository
    {
        public CatTestingDbContext context;
        public CatTestingRepository(CatTestingDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CatTesting>? GetAll()
        {
            var list = context.CatTestings.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public CatTesting? GetById(int Id)
        {
            CatTesting found = new();
            if (found == null)
            {
                return null;
            }
            else return context.CatTestings.Find(Id);
        }
        public void Add(CatTesting toAdd)
        {
            context.CatTestings.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            CatTesting? toDelete = context.CatTestings.Find(Id);
            if (toDelete != null)
            {
                context.CatTestings.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            CatTesting? toUpdate = context.CatTestings.Find(Id);
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
