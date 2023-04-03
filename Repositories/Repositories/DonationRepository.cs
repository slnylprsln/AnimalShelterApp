using DataAccess;
using Entities;
using Repositories.IRepositories;

namespace Repositories.Repositories
{
    public class DonationRepository : IDisposable, IDonationRepository
    {
        public DonationDbContext context;
        public DonationRepository(DonationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Donation>? GetAll()
        {
            var list = context.Donations.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public Donation? GetById(int Id)
        {
            Donation found = new();
            if (found == null)
            {
                return null;
            }
            else return context.Donations.Find(Id);
        }
        public void Add(Donation toAdd)
        {
            context.Donations.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            Donation? toDelete = context.Donations.Find(Id);
            if (toDelete != null)
            {
                context.Donations.Remove(toDelete);
                SaveChanges();
            }
        }

        public void Update(int? Id)
        {
            Donation? toUpdate = context.Donations.Find(Id);
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
