using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class ShelterRepository : IDisposable, IShelterRepository
    {
        public ShelterDbContext context;
        public ShelterRepository(ShelterDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Shelter>? GetAll()
        {
            var list = context.Shelters.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public Shelter? GetById(int Id)
        {
            Shelter found = new();
            if (found == null)
            {
                return null;
            }
            else return context.Shelters.Find(Id);
        }
        public void Add(Shelter toAdd)
        {
            context.Shelters.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            Shelter? toDelete = context.Shelters.Find(Id);
            if (toDelete != null)
            {
                context.Shelters.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            Shelter? toUpdate = context.Shelters.Find(Id);
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
