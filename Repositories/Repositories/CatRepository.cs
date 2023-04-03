using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class CatRepository : IDisposable, ICatRepository
    {
        public CatDbContext context;
        public CatRepository(CatDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Cat>? GetAll()
        {
            var list = context.Cats.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public Cat? GetById(int Id)
        {
            Cat found = new();
            if (found == null)
            {
                return null;
            }
            else return context.Cats.Find(Id);
        }
        public void Add(Cat toAdd)
        {
            context.Cats.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            Cat? toDelete = context.Cats.Find(Id);
            if (toDelete != null)
            {
                context.Cats.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            Cat? toUpdate = context.Cats.Find(Id);
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
