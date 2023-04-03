using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class DogRepository : IDisposable, IDogRepository
    {
        public DogDbContext context;
        public DogRepository(DogDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Dog>? GetAll()
        {
            var list = context.Dogs.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public Dog? GetById(int Id)
        {
            Dog found = new();
            if (found == null)
            {
                return null;
            }
            else return context.Dogs.Find(Id);
        }
        public void Add(Dog toAdd)
        {
            context.Dogs.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            Dog? toDelete = context.Dogs.Find(Id);
            if (toDelete != null)
            {
                context.Dogs.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            Dog? toUpdate = context.Dogs.Find(Id);
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
