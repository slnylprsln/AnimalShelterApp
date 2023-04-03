using DataAccess;
using Data.IRepositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class UserRepository : IDisposable, IUserRepository
    {
        public UserDbContext context;
        public UserRepository(UserDbContext context)
        {
            this.context = context;
        }
        public User? GetByUsername(string username)
        {
            IEnumerable<User>? Users = GetAll();
            User? UserFound = null;
            foreach (var User in Users)
            {
                int compare = String.Compare(User.Username, username);
                if (compare == 0)
                {
                    UserFound = User;
                }
            }
            return UserFound;
        }
        public IEnumerable<User>? GetAll()
        {
            var list = context.Users.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else return list;
        }
        public User? GetById(int? Id)
        {
            User found = new();
            if (found == null)
            {
                return null;
            }
            else return context.Users.Find(Id);
        }
        public void Add(User toAdd)
        {
            context.Users.Add(toAdd);
            SaveChanges();
        }
        public void Delete(int? Id)
        {
            User? toDelete = context.Users.Find(Id);
            if (toDelete != null)
            {
                context.Users.Remove(toDelete);
                SaveChanges();
            }
        }
        public void Update(int? Id)
        {
            User? toUpdate = context.Users.Find(Id);
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
