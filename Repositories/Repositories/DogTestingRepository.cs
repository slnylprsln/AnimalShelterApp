using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class DogTestingRepository : IDisposable, IDogTestingRepository
    {
        public DogTestingDbContext context;
        public DogTestingRepository(DogTestingDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<DogTesting>? GetAll()
        {
            var list = context.DogTestings.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public DogTesting? GetById(int Id)
        {
            DogTesting found = new();
            if (found == null)
            {
                return null;
            }
            else return context.DogTestings.Find(Id);
        }
        public void Add(DogTesting toAdd)
        {
            context.DogTestings.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            DogTesting? toDelete = context.DogTestings.Find(Id);
            if (toDelete != null)
            {
                context.DogTestings.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            DogTesting? toUpdate = context.DogTestings.Find(Id);
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
