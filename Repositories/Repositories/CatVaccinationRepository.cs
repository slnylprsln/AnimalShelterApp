using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class CatVaccinationRepository : IDisposable, ICatVaccinationRepository
    {
        public CatVaccinationDbContext context;
        public CatVaccinationRepository(CatVaccinationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CatVaccination>? GetAll()
        {
            var list = context.CatVaccinations.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public CatVaccination? GetById(int Id)
        {
            CatVaccination found = new();
            if (found == null)
            {
                return null;
            }
            else return context.CatVaccinations.Find(Id);
        }
        public void Add(CatVaccination toAdd)
        {
            context.CatVaccinations.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            CatVaccination? toDelete = context.CatVaccinations.Find(Id);
            if (toDelete != null)
            {
                context.CatVaccinations.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            CatVaccination? toUpdate = context.CatVaccinations.Find(Id);
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
