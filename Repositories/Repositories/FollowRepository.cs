using DataAccess;
using Entities;
using Repositories.IRepositories;

namespace Repositories.Repositories
{
	public class FollowRepository : IDisposable, IFollowRepository
	{
		public FollowDbContext context;
		public FollowRepository(FollowDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Follow>? GetAll()
		{
			var list = context.Follows.ToList();
			if (list.Count == 0)
			{
				return null;
			}
			else return list;
		}

		public Follow? GetById(int Id)
		{
			Follow found = new();
			if (found == null)
			{
				return null;
			}
			else return context.Follows.Find(Id);
		}

		public Follow? GetByUserId(int userId)
		{
			IEnumerable<Follow>? follows = GetAll();
			Follow? FollowFound = null;
			foreach (var follow in follows)
			{
				if (follow.UserId == userId)
				{
					FollowFound = follow;
				}
			}
			return FollowFound;
		}

		public void Add(Follow toAdd)
		{
			context.Follows.Add(toAdd);
			SaveChanges();
		}

		public void Delete(int Id)
		{
			Follow? toDelete = context.Follows.Find(Id);
			if (toDelete != null)
			{
				context.Follows.Remove(toDelete);
				SaveChanges();
			}
		}

		public void Update(int? Id)
		{
			Follow? toUpdate = context.Follows.Find(Id);
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
