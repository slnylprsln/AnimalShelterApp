using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class DogVaccinationRepository : IDisposable, IDogVaccinationRepository
    {
        public DogVaccinationDbContext context;
        public DogVaccinationRepository(DogVaccinationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<DogVaccination>? GetAll()
        {
            var list = context.DogVaccinations.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public DogVaccination? GetById(int Id)
        {
            DogVaccination found = new();
            if (found == null)
            {
                return null;
            }
            else return context.DogVaccinations.Find(Id);
        }
        public void Add(DogVaccination toAdd)
        {
            context.DogVaccinations.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            DogVaccination? toDelete = context.DogVaccinations.Find(Id);
            if (toDelete != null)
            {
                context.DogVaccinations.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int Id)
        {
            DogVaccination? toUpdate = context.DogVaccinations.Find(Id);
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
